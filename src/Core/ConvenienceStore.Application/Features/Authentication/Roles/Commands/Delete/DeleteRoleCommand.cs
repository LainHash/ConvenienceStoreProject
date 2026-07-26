using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Roles.Commands.Delete
{
    public record DeleteRoleCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}
