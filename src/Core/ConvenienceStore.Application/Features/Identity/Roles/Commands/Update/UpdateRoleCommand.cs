using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Roles;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Roles.Commands.Update
{
    public record UpdateRoleCommand(string Id, UpdateRoleRequest Body)
        : IRequest<Result<RoleResponse>>
    {
    }
}
