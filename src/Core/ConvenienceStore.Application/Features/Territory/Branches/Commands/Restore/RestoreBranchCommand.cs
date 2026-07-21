using ConvenienceStore.Application.Models.Results;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Commands.Restore
{
    public record RestoreBranchCommand(string Id)
        : IRequest<Result<object>>
    {
    }
}
