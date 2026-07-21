using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Territory;
using ConvenienceStore.Contract.DTOs.Territory.Branches;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Commands.Update
{
    internal class UpdateBranchCommandHandler
        : IRequestHandler<UpdateBranchCommand, Result<BranchResponse>>
    {
        private readonly IBranchService _branchService;

        public UpdateBranchCommandHandler(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<Result<BranchResponse>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateBranchSpecification(request);
            var response = await _branchService.UpdateAsync(specification, cancellationToken);
            return response;
        }
    }
}
