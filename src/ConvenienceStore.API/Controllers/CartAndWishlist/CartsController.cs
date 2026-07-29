using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Commands.AddItem;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId;
using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetBySessionId;
using ConvenienceStore.Contract.DTOs.CartAndWishlist.Carts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ConvenienceStore.API.Controllers.CartAndWishlist
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("/api/Customers/{userId}/cart")]
        public async Task<IActionResult> GetCustomerCart(
            [FromRoute] string userId,
            CancellationToken cancellationToken)
        {
            var query = new GetCartByCustomerIdQuery(userId);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("/api/Guests/{sessionId}/cart")]
        public async Task<IActionResult> GetGuestCart(
            [FromRoute] string sessionId,
            CancellationToken cancellationToken)
        {
            var query = new GetCartBySessionIdQuery(sessionId);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddItem(
            [FromBody] AddCartItemRequest body,
            CancellationToken cancellationToken)
        {
            var command = new AddCartItemCommand(body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
