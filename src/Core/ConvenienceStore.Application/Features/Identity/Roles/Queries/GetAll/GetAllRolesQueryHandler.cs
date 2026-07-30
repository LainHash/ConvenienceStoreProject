using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Roles;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Roles.Queries.GetAll
{
    internal class GetAllRolesQueryHandler
        : IRequestHandler<GetAllRolesQuery, PageResult<IEnumerable<RoleResponse>>>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<PageResult<IEnumerable<RoleResponse>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllRolesSpecification(request);
            var response = await _roleService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
