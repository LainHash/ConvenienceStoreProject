using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Territory;
using ConvenienceStore.Contract.DTOs.Territory.Branches;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Commands.Create
{
    internal class CreateBranchCommandHandler
        : IRequestHandler<CreateBranchCommand, Result<BranchResponse>>
    {
        private readonly IBranchService _branchService;

        public CreateBranchCommandHandler(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<Result<BranchResponse>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _branchService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
