using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;

namespace ConvenienceStore.Application.Services.CartAndWishlist
{
    public interface ICartService
    {
        Task InitializeAsync(
            int customerId,
            CancellationToken cancellationToken);

        Task<Result<CartResponse>> GetByCustomerIdAsync(
            GetCartByCustomerIdSpecification specification,
            CancellationToken cancellationToken);
    }
}
