using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Territory;
using ConvenienceStore.Contract.DTOs.Territory.Branches;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Queries.GetById
{
    internal class GetBranchByIdQueryHandler
        : IRequestHandler<GetBranchByIdQuery, Result<BranchResponse>>
    {
        private readonly IBranchService _branchService;

        public GetBranchByIdQueryHandler(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<Result<BranchResponse>> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetBranchByIdSpecification(request);
            var response = await _branchService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
