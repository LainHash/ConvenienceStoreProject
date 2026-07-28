using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetBySessionId
{
    public record GetCartBySessionIdQuery(string SessionId)
        : IRequest<Result<CartResponse>>
    {
    }
}
