using ConvenienceStore.Application.Features.CartAndWishlist.Carts.Queries.GetByCustomerId;
using ConvenienceStore.Application.Features.Guest.Customers.Queries.GetAll;
using ConvenienceStore.Application.Features.Guest.Customers.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Guest
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllCustomersQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var query = new GetCustomerByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}/cart")]
        public async Task<IActionResult> GetCart(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var query = new GetCartByCustomerIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
