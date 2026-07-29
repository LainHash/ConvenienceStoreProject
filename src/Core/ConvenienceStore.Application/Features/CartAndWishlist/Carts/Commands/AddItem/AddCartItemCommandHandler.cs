using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.AddItem
{
    internal class AddCartItemCommandHandler(ICartService cartService)
                : IRequestHandler<AddCartItemCommand, Result<CartResponse>>
    {
        private readonly ICartService _cartService = cartService;

        public async Task<Result<CartResponse>> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var specification = new AddCartItemSpecification(request);
            var response = await _cartService.AddItemAsync(specification, cancellationToken);
            return response;
        }
    }
}
