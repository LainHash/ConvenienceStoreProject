using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Queries.GetAll
{
    internal class GetAllUsersQueryHandler(IUserService userService)
                : IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserResponse>>>
    {
        private readonly IUserService _userService = userService;

        public async Task<Result<IEnumerable<UserResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllUsersSpecification(request);
            var response = await _userService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
