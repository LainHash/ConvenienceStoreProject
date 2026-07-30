using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Queries.GetById
{
    internal class GetUserByIdQueryHandler(IUserService userService)
                : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
    {
        private readonly IUserService _userService = userService;

        public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetUserByIdSpecification(request);
            var response = await _userService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
