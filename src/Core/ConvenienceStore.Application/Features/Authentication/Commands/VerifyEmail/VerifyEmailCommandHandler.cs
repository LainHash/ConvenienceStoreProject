using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Authentication;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Commands.VerifyEmail
{
    internal class VerifyEmailCommandHandler(IAuthenticationService authenticationService)
        : IRequestHandler<VerifyEmailCommand, Result<object>>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<Result<object>> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.VerifyEmailAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
