using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Territory;
using ConvenienceStore.Contract.DTOs.Territory;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Queries.GetAll
{
    internal class GetAllBranchesQueryHandler
        : IRequestHandler<GetAllBranchesQuery, Result<IEnumerable<BranchResponse>>>
    {
        private readonly IBranchService _branchService;

        public GetAllBranchesQueryHandler(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<Result<IEnumerable<BranchResponse>>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllBranchesSpecification(request);
            var response = await _branchService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
