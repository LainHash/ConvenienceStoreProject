using AutoMapper;
using ConvenienceStore.Application.Features.Identity.Users.Commands.Update;
using ConvenienceStore.Application.Features.Identity.Users.Queries.GetAll;
using ConvenienceStore.Application.Features.Identity.Users.Queries.GetById;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Identity;
using System.Net;

namespace ConvenienceStore.Persistence.Services.Identity
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<UserResponse>>> GetAllAsync(
            GetAllUsersSpecification specification,
            CancellationToken cancellationToken)
        {
            var users = await _userRepository.ToListAsync(specification, cancellationToken);
            if (!users.Any())
            {
                return Result<IEnumerable<UserResponse>>
                    .Fail(Error<User>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<UserResponse>>(users);
            return Result<IEnumerable<UserResponse>>
                .Succeed(response, Success<User>.Retrieved);
        }

        public async Task<Result<UserResponse>> GetByIdAsync(
            GetUserByIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(specification, cancellationToken);
            if(user is null)
            {
                return Result<UserResponse>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<UserResponse>(user);
            return Result<UserResponse>
                .Succeed(response, Success<User>.Retrieved);
        }

        public async Task<Result<UserResponse>> UpdateAsync(
            UpdateUserSpecification specification,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(specification, cancellationToken);
            if (user is null)
            {
                return Result<UserResponse>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            _mapper.Map(specification.Body, user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<UserResponse>(user);
            return Result<UserResponse>
                .Succeed(response, Success<User>.Updated, HttpStatusCode.Accepted);
        }
    }
}
