using ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmCurrentEmailChange;
using ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmEmailChange;
using ConvenienceStore.Application.Features.Identity.Users.Commands.RequestEmailChange;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Email;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Identity;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Identity
{
    internal class EmailChangeService : IEmailChangeService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailChangeRequestRepository _emailChangeRequestRepository;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;

        public EmailChangeService(
            IUserRepository userRepository,
            IEmailChangeRequestRepository emailChangeRequestRepository,
            IEmailService emailService,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _emailChangeRequestRepository = emailChangeRequestRepository;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }

        // ─── Bước 1: Yêu cầu đổi email ────────────────────────────────────────

        public async Task<Result<object>> RequestEmailChangeAsync(
            RequestEmailChangeSpecification specification,
            CancellationToken cancellationToken)
        {
            // 1. Tìm user
            var user = await _userRepository.FindAsync(specification, cancellationToken);
            if (user is null)
                return Result<object>.Fail(Error<User>.NotFound, HttpStatusCode.NotFound);

            // 2. Email mới phải khác email hiện tại
            if (string.Equals(user.Email, specification.NewEmail, StringComparison.OrdinalIgnoreCase))
                return Result<object>.Fail("New email must be different from your current email.");

            // 3. Kiểm tra email mới chưa được dùng bởi user khác
            var existing = await _userRepository.FindByEmailAsync(specification.NewEmail, cancellationToken);
            if (existing is not null)
                return Result<object>.Fail("This email is already in use.", HttpStatusCode.Conflict);

            // 4. Hủy request cũ nếu có (yêu cầu từ user)
            var pendingRequest = await _emailChangeRequestRepository
                .FindPendingByUserIdAsync(user.Id, cancellationToken);
            if (pendingRequest is not null)
                _emailChangeRequestRepository.Remove(pendingRequest);

            // 5. Tạo EmailChangeRequest mới với OTP 6 chữ số
            var otp = GenerateOtp();
            var emailChangeRequest = EmailChangeRequest.Create(user.Id, specification.NewEmail);
            emailChangeRequest.SetVerificationCode(otp);

            _emailChangeRequestRepository.Add(emailChangeRequest);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // 6. Gửi email OTP đến địa chỉ HIỆN TẠI
            var message = EmailMessage.ForCurrentEmailConfirmation(user.UserName, otp);
            await _emailService.SendEmailAsync(user.Email, message, cancellationToken);

            return Result<object>.Succeed(
                default,
                "A verification code has been sent to your current email address.",
                HttpStatusCode.OK);
        }

        // ─── Bước 2: Xác nhận OTP từ email hiện tại ───────────────────────────

        public async Task<Result<object>> ConfirmCurrentEmailChangeAsync(
            ConfirmCurrentEmailChangeSpecification specification,
            CancellationToken cancellationToken)
        {
            // 1. Tìm user
            var user = await _userRepository.FindAsync(specification, cancellationToken);
            if (user is null)
                return Result<object>.Fail(Error<User>.NotFound, HttpStatusCode.NotFound);

            // 2. Tìm pending request đang chờ xác nhận current email
            var pendingRequest = await _emailChangeRequestRepository
                .FindAwaitingCurrentConfirmAsync(user.Id, cancellationToken);
            if (pendingRequest is null)
                return Result<object>.Fail("No pending email change request found.", HttpStatusCode.NotFound);

            // 3. Kiểm tra OTP hết hạn trước
            if (pendingRequest.IsExpired())
                return Result<object>.Fail("The verification code has expired. Please request a new one.");

            // 4. Kiểm tra OTP có khớp không
            if (!pendingRequest.IsCodeValid(specification.VerificationCode))
                return Result<object>.Fail("The verification code is incorrect.");

            // 5. Xác nhận current email (reset OTP cũ)
            pendingRequest.ConfirmCurrentEmail();

            // 6. Sinh OTP mới cho email mới
            var newOtp = GenerateOtp();
            pendingRequest.SetVerificationCode(newOtp);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // 7. Gửi email OTP đến địa chỉ MỚI
            var message = EmailMessage.ForEmailChange(user.UserName, newOtp);
            await _emailService.SendEmailAsync(pendingRequest.NewEmail, message, cancellationToken);

            return Result<object>.Succeed(
                default,
                "A verification code has been sent to your new email address.",
                HttpStatusCode.OK);
        }

        // ─── Bước 3: Xác nhận OTP từ email mới ────────────────────────────────

        public async Task<Result<object>> ConfirmEmailChangeAsync(
            ConfirmEmailChangeSpecification specification,
            CancellationToken cancellationToken)
        {
            // 1. Tìm user
            var user = await _userRepository.FindAsync(specification, cancellationToken);
            if (user is null)
                return Result<object>.Fail(Error<User>.NotFound, HttpStatusCode.NotFound);

            // 2. Tìm pending request đã qua bước 2 (đang chờ xác nhận email mới)
            var pendingRequest = await _emailChangeRequestRepository
                .FindAwaitingNewConfirmAsync(user.Id, cancellationToken);
            if (pendingRequest is null)
                return Result<object>.Fail("No pending email change request found.", HttpStatusCode.NotFound);

            // 3. Kiểm tra OTP hết hạn trước
            if (pendingRequest.IsExpired())
                return Result<object>.Fail("The verification code has expired. Please request a new one.");

            // 4. Kiểm tra OTP có khớp không
            if (!pendingRequest.IsCodeValid(specification.VerificationCode))
                return Result<object>.Fail("The verification code is incorrect.");

            // 5. Cập nhật email trên User
            user.ChangeEmail(pendingRequest.NewEmail);

            // 6. Xóa EmailChangeRequest đã hoàn thành
            _emailChangeRequestRepository.Remove(pendingRequest);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>.Succeed(
                default,
                "Your email has been updated successfully.",
                HttpStatusCode.Accepted);
        }

        // ─── Helper ───────────────────────────────────────────────────────────

        private static string GenerateOtp()
            => Random.Shared.Next(100_000, 999_999).ToString();
    }
}
