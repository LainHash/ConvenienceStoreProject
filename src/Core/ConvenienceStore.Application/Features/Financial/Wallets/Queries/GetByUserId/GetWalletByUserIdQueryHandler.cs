using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Financial;
using ConvenienceStore.Contract.DTOs.Financial;
using MediatR;

namespace ConvenienceStore.Application.Features.Financial.Wallets.Queries.GetByUserId
{
    internal class GetWalletByUserIdQueryHandler(IWalletService walletService)
                : IRequestHandler<GetWalletByUserIdQuery, Result<WalletResponse>>
    {
        private readonly IWalletService _walletService = walletService;

        public async Task<Result<WalletResponse>> Handle(GetWalletByUserIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetWalletByUserIdSpecification(request);
            var response = await _walletService.GetByUserIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
