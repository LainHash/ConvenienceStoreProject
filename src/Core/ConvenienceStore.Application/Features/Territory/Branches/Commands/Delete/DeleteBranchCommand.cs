using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Commands.Delete
{
    public record DeleteBranchCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}
