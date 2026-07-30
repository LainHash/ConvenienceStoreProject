using ConvenienceStore.Application.Features.Identity.Roles.Commands.Update;
using ConvenienceStore.Application.Features.Identity.Roles.Queries.GetAll;
using ConvenienceStore.Application.Features.Identity.Roles.Queries.GetById;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Roles;

namespace ConvenienceStore.Application.Services.Identity
{
    public interface IRoleService
    {
        Task<PageResult<IEnumerable<RoleResponse>>> GetAllAsync(
            GetAllRolesSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<RoleResponse>> GetByIdAsync(
            GetRoleByIdSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<RoleResponse>> CreateAsync(
            CreateRoleRequest request,
            CancellationToken cancellationToken);

        Task<Result<RoleResponse>> UpdateAsync(
            UpdateRoleSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<object>> DeleteAsync(
            string id,
            CancellationToken cancellationToken);

        Task<Result<object>> RestoreAsync(
            string id,
            CancellationToken cancellationToken);
    }
}
