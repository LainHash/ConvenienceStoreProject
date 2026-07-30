using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Commands.AddItem
{
    public record AddWishlistItemCommand(AddWishlistItemRequest Body)
        : IRequest<Result<WishlistResponse>>
    {
    }
}
