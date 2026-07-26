using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Roles;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Roles.Commands.Update
{
    internal class UpdateRoleCommandHandler
        : IRequestHandler<UpdateRoleCommand, Result<RoleResponse>>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result<RoleResponse>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateRoleSpecification(request);
            var response = await _roleService.UpdateAsync(specification, cancellationToken);
            return response;
        }
    }
}
