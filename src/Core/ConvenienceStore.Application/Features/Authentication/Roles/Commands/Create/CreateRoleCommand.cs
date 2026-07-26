using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Roles;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Roles.Commands.Create
{
    public record CreateRoleCommand(CreateRoleRequest Body)
        : IRequest<Result<RoleResponse>>
    {
    }
}
