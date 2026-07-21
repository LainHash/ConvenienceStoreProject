using ConvenienceStore.Application.Features.Territory.Branches.Commands.Update;
using ConvenienceStore.Application.Features.Territory.Branches.Queries.GetAll;
using ConvenienceStore.Application.Features.Territory.Branches.Queries.GetById;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Territory.Branches;

namespace ConvenienceStore.Application.Services.Territory
{
    public interface IBranchService
    {
        Task<Result<IEnumerable<BranchResponse>>> GetAllAsync(GetAllBranchesSpecification specification, CancellationToken cancellationToken);
        Task<Result<BranchResponse>> GetByIdAsync(GetBranchByIdSpecification specification, CancellationToken cancellationToken);
        Task<Result<BranchResponse>> CreateAsync(CreateBranchRequest request, CancellationToken cancellationToken);
        Task<Result<BranchResponse>> UpdateAsync(UpdateBranchSpecification specification, CancellationToken cancellationToken);
        Task<Result<object>> DeleteAsync(string id, CancellationToken cancellationToken);
        Task<Result<object>> RestoreAsync(string id, CancellationToken cancellationToken);
    }
}
