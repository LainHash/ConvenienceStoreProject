using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Territory;
using MediatR;

namespace ConvenienceStore.Application.Features.Territory.Branches.Commands.Restore
{
    internal class RestoreBranchCommandHandler
        : IRequestHandler<RestoreBranchCommand, Result<object>>
    {
        private readonly IBranchService _branchService;

        public RestoreBranchCommandHandler(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<Result<object>> Handle(RestoreBranchCommand request, CancellationToken cancellationToken)
        {
            var response = await _branchService.RestoreAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
