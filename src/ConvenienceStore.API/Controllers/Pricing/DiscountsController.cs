using ConvenienceStore.API.Extensions;
using ConvenienceStore.Application.Features.Pricing.Discounts.Commands.Create;
using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetAll;
using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetById;
using ConvenienceStore.Application.Features.Pricing.Discounts.Queries.GetByName;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var query = new GetDiscountByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetOneName(
            [FromRoute] string name,
            CancellationToken cancellationToken)
        {
            var query = new GetDiscountByNameQuery(name);
            var result = await _mediator.Send(query, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateDiscountRequest body,
            CancellationToken cancellationToken)
        {
            var command = new CreateDiscountCommand(body);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }
    }
}
