using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.RequestEmailChange
{
    internal class RequestEmailChangeCommandHandler(IEmailChangeService emailChangeService)
        : IRequestHandler<RequestEmailChangeCommand, Result<object>>
    {
        private readonly IEmailChangeService _emailChangeService = emailChangeService;

        public async Task<Result<object>> Handle(
            RequestEmailChangeCommand request,
            CancellationToken cancellationToken)
        {
            var specification = new RequestEmailChangeSpecification(request);
            return await _emailChangeService.RequestEmailChangeAsync(specification, cancellationToken);
        }
    }
}
