using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Territory;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Commands.Update
{
    public record UpdateBranchCommand(string Id, UpdateBranchRequest Body)
        : IRequest<Result<BranchResponse>>
    {
    }
}
