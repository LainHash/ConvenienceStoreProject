using ConvenienceStore.API.Extensions;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.AddItem;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.UpdateItemQuantity;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetBySessionId;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.CartAndWishlist
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("/api/Customers/user/{userId}/cart")]
        public async Task<IActionResult> GetCustomerCart(
            [FromRoute] string userId,
            CancellationToken cancellationToken)
        {
            var query = new GetCartByCustomerIdQuery(userId);
            var result = await _mediator.Send(query, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpGet("/api/Guests/{sessionId}/cart")]
        public async Task<IActionResult> GetGuestCart(
            [FromRoute] string sessionId,
            CancellationToken cancellationToken)
        {
            var query = new GetCartBySessionIdQuery(sessionId);
            var result = await _mediator.Send(query, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddItem(
            [FromBody] AddCartItemRequest body,
            CancellationToken cancellationToken)
        {
            var command = new AddCartItemCommand(body);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPatch("items/{cartItemId}")]
        public async Task<IActionResult> UpdateItemQuantity(
            [FromRoute] string cartItemId,
            [FromBody] UpdateCartItemQuantityRequest body,
            CancellationToken cancellationToken)
        {
            var command = new UpdateCartItemQuantityCommand(cartItemId, body);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }
    }
}
