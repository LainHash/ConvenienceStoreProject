using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Territory;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Commands.Create
{
    public record CreateBranchCommand(CreateBranchRequest Body)
        : IRequest<Result<BranchResponse>>
    {
    }
}
