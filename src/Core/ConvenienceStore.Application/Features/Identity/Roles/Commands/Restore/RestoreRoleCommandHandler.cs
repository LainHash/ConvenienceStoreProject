using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Roles.Commands.Restore
{
    internal class RestoreRoleCommandHandler
        : IRequestHandler<RestoreRoleCommand, Result<object>>
    {
        private readonly IRoleService _roleService;

        public RestoreRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result<object>> Handle(RestoreRoleCommand request, CancellationToken cancellationToken)
        {
            var response = await _roleService.RestoreAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
