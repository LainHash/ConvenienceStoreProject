using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Roles.Commands.Restore
{
    public record RestoreRoleCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}
