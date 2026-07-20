using ConvenienceStore.Application.Features.Catalog.Categories.Commands.Create;
using ConvenienceStore.Application.Features.Catalog.Categories.Commands.Update;
using ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Categories.Queries.GetById;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Catalog
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllCategoriesQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateCategoryRequest body,
            CancellationToken cancellationToken)
        {
            var command = new CreateCategoryCommand(body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] string id,
            [FromBody] UpdateCategoryRequest body,
            CancellationToken cancellationToken)
        {
            var command = new UpdateCategoryCommand(id, body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
