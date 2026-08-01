using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmCurrentEmailChange
{
    internal class ConfirmCurrentEmailChangeCommandHandler(IEmailChangeService emailChangeService)
        : IRequestHandler<ConfirmCurrentEmailChangeCommand, Result<object>>
    {
        private readonly IEmailChangeService _emailChangeService = emailChangeService;

        public async Task<Result<object>> Handle(
            ConfirmCurrentEmailChangeCommand request,
            CancellationToken cancellationToken)
        {
            var specification = new ConfirmCurrentEmailChangeSpecification(request);
            return await _emailChangeService.ConfirmCurrentEmailChangeAsync(specification, cancellationToken);
        }
    }
}
