using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ChangePassword
{
    internal class ChangeUserPasswordCommandHandler(IUserService userService)
                : IRequestHandler<ChangeUserPasswordCommand, Result<object>>
    {
        private readonly IUserService _userService = userService;

        public async Task<Result<object>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var specification = new ChangeUserPasswordSpecification(request);
            var response = await _userService.ChangePasswordAsync(specification, cancellationToken);
            return response;
        }
    }
}
