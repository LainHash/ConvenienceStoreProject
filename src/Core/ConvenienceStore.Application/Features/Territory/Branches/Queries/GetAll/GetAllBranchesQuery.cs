using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Territory.Branches;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Queries.GetAll
{
    public record GetAllBranchesQuery
        : IRequest<Result<IEnumerable<BranchResponse>>>
    {
    }
}
