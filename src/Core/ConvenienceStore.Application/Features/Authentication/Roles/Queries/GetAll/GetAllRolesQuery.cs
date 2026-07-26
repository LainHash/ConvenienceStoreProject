using ConvenienceStore.Application.Models;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Roles;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Roles.Queries.GetAll
{
    public record GetAllRolesQuery
        : PageQuery, IRequest<PageResult<IEnumerable<RoleResponse>>>
    {
    }
}
