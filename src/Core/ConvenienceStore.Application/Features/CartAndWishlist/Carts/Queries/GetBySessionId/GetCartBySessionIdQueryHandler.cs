using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetBySessionId
{
    internal class GetCartBySessionIdQueryHandler(ICartService cartService)
                : IRequestHandler<GetCartBySessionIdQuery, Result<CartResponse>>
    {
        private readonly ICartService _cartService = cartService;

        public async Task<Result<CartResponse>> Handle(GetCartBySessionIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetCartBySessionIdSpecification(request);
            var response = await _cartService.GetBySessionIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
