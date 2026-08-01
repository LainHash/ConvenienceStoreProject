using ConvenienceStore.Application.Features.Financial.Wallets.Queries.GetByUserId;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Financial;

namespace ConvenienceStore.Application.Services.Financial
{
    public interface IWalletService
    {
        Task<Result<WalletResponse>> GetByUserIdAsync(
            GetWalletByUserIdSpecification specification,
            CancellationToken cancellationToken);
    }
}
