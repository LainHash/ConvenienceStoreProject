using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Financial;
using MediatR;

namespace ConvenienceStore.Application.Features.Financial.Wallets.Queries.GetByUserId
{
    public record GetWalletByUserIdQuery(string UserId)
        : IRequest<Result<WalletResponse>>
    {
    }
}
