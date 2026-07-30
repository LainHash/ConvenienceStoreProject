using AutoMapper;
using ConvenienceStore.Application.Features.Identity.Users.Queries.GetAll;
using ConvenienceStore.Application.Models.Messages;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Identity;

namespace ConvenienceStore.Persistence.Services.Identity
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
    }
}
