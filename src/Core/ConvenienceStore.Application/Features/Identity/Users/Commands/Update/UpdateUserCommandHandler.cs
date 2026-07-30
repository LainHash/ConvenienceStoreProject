using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.Update
{
    internal class UpdateUserCommandHandler(IUserService userService)
                : IRequestHandler<UpdateUserCommand, Result<UserResponse>>
    {
        private readonly IUserService _userService = userService;

        public async Task<Result<UserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateUserSpecification(request);
            var response = await _userService.UpdateAsync(specification, cancellationToken);
            return response;
        }
    }
}
