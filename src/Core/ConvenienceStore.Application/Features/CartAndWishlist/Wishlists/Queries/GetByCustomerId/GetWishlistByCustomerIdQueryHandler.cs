using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetByCustomerId
{
    internal class GetWishlistByCustomerIdQueryHandler(IWishlistService wishlistService)
                : IRequestHandler<GetWishlistByCustomerIdQuery, Result<WishlistResponse>>
    {
        private readonly IWishlistService _wishlistService = wishlistService;

        public async Task<Result<WishlistResponse>> Handle(GetWishlistByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetWishlistByCustomerIdSpecification(request);
            var response = await _wishlistService.GetByCustomerIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
