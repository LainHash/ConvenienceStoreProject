using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.UpdateItemQuantity
{
    public record UpdateCartItemQuantityCommand(string CartItemId, UpdateCartItemQuantityRequest Body)
        : IRequest<Result<CartResponse>>
    {
    }
}
