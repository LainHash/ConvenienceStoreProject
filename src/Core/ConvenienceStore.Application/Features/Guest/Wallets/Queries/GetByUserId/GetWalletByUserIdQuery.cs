using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Financial;
using MediatR;

namespace ConvenienceStore.Application.Features.Guest.Wallets.Queries.GetByUserId
{
    public record GetWalletByUserIdQuery(string UserId)
        : IRequest<Result<WalletResponse>>
    {
    }
}
