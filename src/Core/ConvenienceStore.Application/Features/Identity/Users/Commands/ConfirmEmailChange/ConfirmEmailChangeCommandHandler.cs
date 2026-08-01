using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmEmailChange
{
    internal class ConfirmEmailChangeCommandHandler(IEmailChangeService emailChangeService)
        : IRequestHandler<ConfirmEmailChangeCommand, Result<object>>
    {
        private readonly IEmailChangeService _emailChangeService = emailChangeService;

        public async Task<Result<object>> Handle(
            ConfirmEmailChangeCommand request,
            CancellationToken cancellationToken)
        {
            var specification = new ConfirmEmailChangeSpecification(request);
            return await _emailChangeService.ConfirmEmailChangeAsync(specification, cancellationToken);
        }
    }
}
