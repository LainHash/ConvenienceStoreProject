using ConvenienceStore.Application.Features.Guest.Wallets.Queries.GetByUserId;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Financial;

namespace ConvenienceStore.Application.Services.Guest
{
    public interface IWalletService
    {
        Task<Result<WalletResponse>> GetByUserIdAsync(
            GetWalletByUserIdSpecification specification,
            CancellationToken cancellationToken);
    }
}
