using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Roles.Commands.Delete
{
    internal class DeleteRoleCommandHandler
        : IRequestHandler<DeleteRoleCommand, Result<object>>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result<object>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var response = await _roleService.DeleteAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
