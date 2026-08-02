using ConvenienceStore.API.Extensions;
using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Pricing
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllDiscountsQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return this.ToActionResult(result);
        }
    }
}
