using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using ConvenienceStore.Domain.Entities.CartAndWishlist;

namespace ConvenienceStore.Application.Services.CartAndWishlist
{
    public interface ICartService
    {
        Task<Cart> InitializeAsync(
            int customerId,
            CancellationToken cancellationToken);

        Task<Cart> InitializeAsync(
            string sessionId,
            CancellationToken cancellationToken);

        Task<Result<CartResponse>> GetByCustomerIdAsync(
            GetCartByCustomerIdSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<CartResponse>> AddItemAsync();
    }
}
