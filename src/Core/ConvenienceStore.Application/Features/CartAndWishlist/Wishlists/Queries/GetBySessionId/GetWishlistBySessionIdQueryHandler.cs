using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetBySessionId
{
    internal class GetWishlistBySessionIdQueryHandler(IWishlistService wishlistService)
                : IRequestHandler<GetWishlistBySessionIdQuery, Result<WishlistResponse>>
    {
        private readonly IWishlistService _wishlistService = wishlistService;

        public async Task<Result<WishlistResponse>> Handle(GetWishlistBySessionIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetWishlistBySessionIdSpecification(request);
            var response = await _wishlistService.GetBySessionIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
