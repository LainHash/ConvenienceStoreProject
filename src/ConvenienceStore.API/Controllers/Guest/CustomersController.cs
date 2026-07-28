using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId;
using ConvenienceStore.Application.Features.Guest.Customers.Queries.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Guest
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOne(
            [FromRoute] string userId,
            CancellationToken cancellationToken)
        {
            var query = new GetCustomerByUserIdQuery(userId);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{userId}/cart")]
        public async Task<IActionResult> GetCart(
            [FromRoute] string userId,
            CancellationToken cancellationToken)
        {
            var query = new GetCartByCustomerIdQuery(userId);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
