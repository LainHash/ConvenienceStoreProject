using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetBySessionId
{
    public record GetWishlistBySessionIdQuery(string SessionId)
        : IRequest<Result<WishlistResponse>>
    {
    }
}
