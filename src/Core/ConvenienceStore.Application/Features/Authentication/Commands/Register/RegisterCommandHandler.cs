using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Authentication;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Commands.Register
{
    internal class RegisterCommandHandler(IAuthenticationService authenticationService)
                : IRequestHandler<RegisterCommand, Result<object>>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<Result<object>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.RegisterAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
