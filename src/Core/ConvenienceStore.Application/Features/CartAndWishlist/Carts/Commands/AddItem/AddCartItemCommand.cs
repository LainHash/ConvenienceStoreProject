using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.AddItem
{
    public record AddCartItemCommand(string CustomerId, AddCartItemRequest Body)
        : IRequest<Result<CartResponse>>
    {
    }
}
