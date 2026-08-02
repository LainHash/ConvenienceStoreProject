using ConvenienceStore.API.Extensions;
using ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Commands.AddItem;
using ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetByCustomerId;
using ConvenienceStore.Application.Features.CartAndWishlist.Wishlists.Queries.GetBySessionId;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Wishlists;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ConvenienceStore.API.Controllers.CartAndWishlist
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("/api/Customers/user/{userId}/wishlist")]
        public async Task<IActionResult> GetCustomerWishlist(
            [FromRoute] string userId,
            CancellationToken cancellationToken)
        {
            var query = new GetWishlistByCustomerIdQuery(userId);
            var result = await _mediator.Send(query, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpGet("/api/Guests/{sessionId}/wishlist")]
        public async Task<IActionResult> GetGuestWishlist(
            [FromRoute] string sessionId,
            CancellationToken cancellationToken)
        {
            var query = new GetWishlistBySessionIdQuery(sessionId);
            var result = await _mediator.Send(query, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddItem(
            [FromBody] AddWishlistItemRequest body,
            CancellationToken cancellationToken)
        {
            var command = new AddWishlistItemCommand(body);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }
    }
}
