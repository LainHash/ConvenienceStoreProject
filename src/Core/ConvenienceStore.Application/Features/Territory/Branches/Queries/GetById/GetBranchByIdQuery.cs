using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Territory.Branches;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Queries.GetById
{
    public record GetBranchByIdQuery(string Id)
        : IRequest<Result<BranchResponse>>
    {
    }
}
