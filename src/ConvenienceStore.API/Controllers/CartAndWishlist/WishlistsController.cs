using ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetByCustomerId;
using ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetBySessionId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.CartAndWishlist
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("/api/Customers/{userId}/wishlist")]
        public async Task<IActionResult> GetCustomerWishlist(
            [FromRoute] string userId,
            CancellationToken cancellationToken)
        {
            var query = new GetWishlistByCustomerIdQuery(userId);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("/api/Guests/{sessionId}/wishlist")]
        public async Task<IActionResult> GetGuestWishlist(
            [FromRoute] string sessionId,
            CancellationToken cancellationToken)
        {
            var query = new GetWishlistBySessionIdQuery(sessionId);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
