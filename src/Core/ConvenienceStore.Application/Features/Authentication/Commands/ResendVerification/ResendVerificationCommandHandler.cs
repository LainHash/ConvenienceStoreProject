using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Authentication;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Commands.ResendVerification
{
    internal class ResendVerificationCommandHandler(IAuthenticationService authenticationService)
                : IRequestHandler<ResendVerificationCommand, Result<object>>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<Result<object>> Handle(ResendVerificationCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.ResendVerificationAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
