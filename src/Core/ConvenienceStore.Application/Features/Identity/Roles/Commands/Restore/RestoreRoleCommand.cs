using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Roles.Commands.Restore
{
    public record RestoreRoleCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}
