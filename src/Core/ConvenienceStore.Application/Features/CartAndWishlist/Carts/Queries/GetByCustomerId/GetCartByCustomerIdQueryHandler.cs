using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.CartAndWishlist;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using MediatR;

namespace ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId
{
    internal class GetCartByCustomerIdQueryHandler(ICartService cartService)
                : IRequestHandler<GetCartByCustomerIdQuery, Result<CartResponse>>
    {
        private readonly ICartService _cartService = cartService;

        public async Task<Result<CartResponse>> Handle(GetCartByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetCartByCustomerIdSpecification(request);
            var response = await _cartService.GetByCustomerIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
