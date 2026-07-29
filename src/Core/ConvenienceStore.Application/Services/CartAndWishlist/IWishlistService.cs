using ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetByCustomerId;
using ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetBySessionId;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;

namespace ConvenienceStore.Application.Services.CartAndWishlist
{
    public interface IWishlistService
    {
        Task<Result<WishlistResponse>> GetByCustomerIdAsync(
            GetWishlistByCustomerIdSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<WishlistResponse>> GetBySessionIdAsync(
            GetWishlistBySessionIdSpecification specification,
            CancellationToken cancellationToken);
    }
}
