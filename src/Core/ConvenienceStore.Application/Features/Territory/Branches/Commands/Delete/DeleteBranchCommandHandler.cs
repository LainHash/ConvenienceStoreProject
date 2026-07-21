using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Territory;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Commands.Delete
{
    internal class DeleteBranchCommandHandler
        : IRequestHandler<DeleteBranchCommand, Result<object>>
    {
        private readonly IBranchService _branchService;

        public DeleteBranchCommandHandler(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<Result<object>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _branchService.DeleteAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
