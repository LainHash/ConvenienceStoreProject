using ConvenienceStore.Application.Features.Catalog.Brands.Commands.Create;
using ConvenienceStore.Application.Features.Catalog.Brands.Commands.Delete;
using ConvenienceStore.Application.Features.Catalog.Brands.Commands.Restore;
using ConvenienceStore.Application.Features.Catalog.Brands.Commands.Update;
using ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetById;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Catalog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetAll(
            [FromQuery] GetAllBrandsQuery query,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var query = new GetBrandByIdQuery(id);
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] CreateBrandRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateBrandCommand(request);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(
            [FromRoute] string id,
            [FromBody] UpdateBrandRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateBrandCommand(id, request);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var command = new DeleteBrandCommand(id);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("{id}/restore")]
        public async Task<ActionResult> Restore(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var command = new RestoreBrandCommand(id);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
