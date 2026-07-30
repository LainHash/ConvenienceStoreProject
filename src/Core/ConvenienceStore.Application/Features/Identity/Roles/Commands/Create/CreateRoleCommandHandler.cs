using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Roles;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Roles.Commands.Create
{
    internal class CreateRoleCommandHandler
        : IRequestHandler<CreateRoleCommand, Result<RoleResponse>>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result<RoleResponse>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = await _roleService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
