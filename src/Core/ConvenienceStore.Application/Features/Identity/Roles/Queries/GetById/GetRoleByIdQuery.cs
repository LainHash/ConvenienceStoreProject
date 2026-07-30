using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Roles;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Roles.Queries.GetById
{
    public record GetRoleByIdQuery(string Id)
        : IRequest<Result<RoleResponse>>
    {
    }
}
