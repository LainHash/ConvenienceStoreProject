using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Commands.AddItem
{
    internal class AddWishlistItemCommandHandler(IWishlistService wishlistService)
                : IRequestHandler<AddWishlistItemCommand, Result<WishlistResponse>>
    {
        private readonly IWishlistService _wishlistService = wishlistService;

        public async Task<Result<WishlistResponse>> Handle(AddWishlistItemCommand request, CancellationToken cancellationToken)
        {
            var specification = new AddWishlistItemSpecification(request);
            var response = await _wishlistService.AddItemAsync(specification, cancellationToken);
            return response;
        }
    }
}
