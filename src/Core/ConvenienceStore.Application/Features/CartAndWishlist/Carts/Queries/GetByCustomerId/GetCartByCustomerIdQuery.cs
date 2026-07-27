using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId
{
    public record GetCartByCustomerIdQuery(string CustomerId)
        : IRequest<Result<CartResponse>>
    {
    }
}
