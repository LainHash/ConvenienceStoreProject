using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Authentication;
using ConvenienceStore.Contract.DTOs.Authentication;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Commands.Login
{
    internal class LoginCommandHandler(IAuthenticationService authenticationService)
                : IRequestHandler<LoginCommand, Result<AuthenticationResponse>>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<Result<AuthenticationResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.LoginAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
