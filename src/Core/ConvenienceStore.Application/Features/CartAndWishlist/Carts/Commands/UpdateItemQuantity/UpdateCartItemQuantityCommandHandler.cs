using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.UpdateItemQuantity
{
    internal class UpdateCartItemQuantityCommandHandler(ICartService cartService)
                : IRequestHandler<UpdateCartItemQuantityCommand, Result<CartResponse>>
    {
        private readonly ICartService _cartService = cartService;

        public async Task<Result<CartResponse>> Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateCartItemQuantitySpecification(request);
            var response = await _cartService.UpdateItemQuantityAsync(specification, cancellationToken);
            return response;
        }
    }
}
