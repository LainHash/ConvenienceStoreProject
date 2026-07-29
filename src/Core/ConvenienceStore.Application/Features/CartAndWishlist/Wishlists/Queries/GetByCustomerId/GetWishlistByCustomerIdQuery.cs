using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetByCustomerId
{
    public record GetWishlistByCustomerIdQuery(string UserId)
        : IRequest<Result<WishlistResponse>>
    {
    }
}
