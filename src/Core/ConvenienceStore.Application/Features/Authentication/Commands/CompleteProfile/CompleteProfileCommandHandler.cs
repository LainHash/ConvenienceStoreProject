using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Authentication;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Commands.CompleteProfile
{
    internal class CompleteProfileCommandHandler(IAuthenticationService authenticationService)
                : IRequestHandler<CompleteProfileCommand, Result<object>>
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<Result<object>> Handle(CompleteProfileCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.CompleteProfileAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
