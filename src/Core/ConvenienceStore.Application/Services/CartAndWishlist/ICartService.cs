using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.AddItem;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.UpdateItemQuantity;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetBySessionId;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Domain.Entities.CartAndWishlist;

namespace ConvenienceStore.Application.Services.CartAndWishlist
{
    public interface ICartService
    {
        Task<Result<CartResponse>> GetByCustomerIdAsync(
            GetCartByCustomerIdSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<CartResponse>> GetBySessionIdAsync(
            GetCartBySessionIdSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<CartResponse>> AddItemAsync(
            AddCartItemSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<CartResponse>> UpdateItemQuantityAsync(
            UpdateCartItemQuantitySpecification specification,
            CancellationToken cancellationToken);
    }
}
