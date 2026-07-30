using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Roles;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Roles.Queries.GetById
{
    internal class GetRoleByIdQueryHandler
        : IRequestHandler<GetRoleByIdQuery, Result<RoleResponse>>
    {
        private readonly IRoleService _roleService;

        public GetRoleByIdQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result<RoleResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetRoleByIdSpecification(request);
            var response = await _roleService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
