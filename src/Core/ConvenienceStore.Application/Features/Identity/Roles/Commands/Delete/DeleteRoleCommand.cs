using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Roles.Commands.Delete
{
    public record DeleteRoleCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}
