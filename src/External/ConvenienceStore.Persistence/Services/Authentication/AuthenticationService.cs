using AutoMapper;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Authentication;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Email;
using ConvenienceStore.Contract.DTOs.Authentication;
using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Guest;
using ConvenienceStore.Domain.Repositories.Identity;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IProfileRepository profileRepository,
            ICustomerRepository customerRepository,
            IPasswordHasher passwordHasher,
            IEmailService emailService,
            IUnitOfWork unitOfWork,
            IJwtProvider jwtProvider,
            IMapper mapper,
            ILogger<AuthenticationService> logger)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _profileRepository = profileRepository;
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<AuthenticationResponse>> LoginAsync(
            LoginRequest request,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(request.Email, cancellationToken);
            if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            {
                return Result<AuthenticationResponse>
                    .Fail("Incorrect email or password.", HttpStatusCode.Unauthorized);
            }

            if (!user.IsActive)
            {
                return Result<AuthenticationResponse>
                    .Fail("Account is not active. Please verify your email.", HttpStatusCode.PreconditionRequired);
            }

            var role = await _roleRepository.FindAsync(user.RoleId, cancellationToken);
            var roleName = role?.Name ?? "Customer";

            var token = _jwtProvider.GenerateToken(user.PublicId, user.UserName, user.Email, roleName);

            var response = new AuthenticationResponse
            {
                UserId = user.PublicId,
                UserName = user.UserName,
                Email = user.Email,
                Token = token
            };

            return Result<AuthenticationResponse>
                .Succeed(response, "Login successfully.", HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> RegisterAsync(
            RegisterRequest request,
            CancellationToken cancellationToken = default)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                var existingUser = await _userRepository.FindByEmailAsync(request.Email, cancellationToken);
                if (existingUser != null)
                {
                    return Result<object>
                        .Fail("This email already used. Please use another email.", HttpStatusCode.Conflict);
                }

                var customerRole = await _roleRepository.FindByNameAsync("Customer", cancellationToken);
                if (customerRole == null)
                {
                    return Result<object>
                        .Fail(Error<Role>.NotFound, HttpStatusCode.InternalServerError);
                }

                var verificationCode = GenerateCode();

                var user = _mapper.Map<User>(request);
                user.SetPasswordHash(_passwordHasher.HashPassword(request.Password));
                user.SetRole(customerRole.Id);
                user.SetVerificationCode(verificationCode);
                _userRepository.Add(user);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var customer = new Customer(user.Id);
                _customerRepository.Add(customer);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                try
                {
                    var message = new EmailMessage(user.UserName, verificationCode);
                    await _emailService.SendEmailAsync(user.Email, message, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Send verification email failed.");
                }

                return Result<object>
                     .Succeed(default, "Register successfully. Please check your account to get verification code.", HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);

                _logger.LogError(ex, "Register request failed. Email: {Email}", request.Email);
                return Result<object>
                    .Fail("Register request failed.", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Result<object>> VerifyEmailAsync(
            string userId,
            VerifyEmailRequest request,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(request.Email, cancellationToken);
            if (user == null)
            {
                return Result<object>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            if (user.IsActive)
            {
                return Result<object>
                    .Fail("Account is already active.", HttpStatusCode.Conflict);
            }

            if (user.VerificationCode != request.Code)
            {
                return Result<object>
                    .Fail("Invalid verification code.", HttpStatusCode.Conflict);
            }

            if (user.VerificationCodeExpiresAt < DateTime.UtcNow)
            {
                return Result<object>
                    .Fail("Verification code has expired. Please request a new one.", HttpStatusCode.RequestTimeout);
            }

            user.CompleteVerification();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, "Email verified successfully. You can now login.", HttpStatusCode.Accepted);
        }
        public async Task<Result<object>> CompleteProfileAsync(
            string userId,
            CompleteProfileRequest request,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(userId, cancellationToken);
            if (user == null)
            {
                return Result<object>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            if (!user.IsActive)
            {
                return Result<object>
                    .Fail("Account is not active. Please verify your email first.", HttpStatusCode.PreconditionRequired);
            }

            var customer = await _customerRepository.FindByUserAsync(user.Id, cancellationToken);
            if (customer == null)
            {
                return Result<object>
                    .Fail(Error<Customer>.NotFound, HttpStatusCode.NotFound);
            }

            if (customer.ProfileId.HasValue)
            {
                return Result<object>
                    .Fail("Profile has already been completed.", HttpStatusCode.Conflict);
            }

            var profile = _mapper.Map<Domain.Entities.Identity.Profile>(request);
            _profileRepository.Add(profile);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            customer.CompleteProfile(profile.Id);
            _customerRepository.Update(customer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, "Profile completed successfully.", HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> ResendVerificationAsync(
            ResendVerificationRequest request,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(request.Email, cancellationToken);
            if (user is null)
            {
                return Result<object>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            if (user.IsActive)
            {
                return Result<object>
                    .Fail("Account is already active.", HttpStatusCode.Conflict);
            }

            var newCode = GenerateCode();
            user.SetVerificationCode(newCode);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            try
            {
                var message = new EmailMessage(user.UserName, newCode);
                await _emailService.SendEmailAsync(user.Email, message, cancellationToken);

                return Result<object>
                .Succeed(default, "Verification email resent. Please check your inbox.", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Resend verification email failed. Email: {Email}", user.Email);
                throw;
            }
        }

        private string GenerateCode()
        {
            // Generate 6-digit verification code
            var random = new Random();
            var verificationCode = random.Next(100000, 999999).ToString();
            return verificationCode;
        }
    }
}
