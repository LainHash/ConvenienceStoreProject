using ConvenienceStore.API.Extensions;
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
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllBrandsQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var query = new GetBrandByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateBrandRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateBrandCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] string id,
            [FromBody] UpdateBrandRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateBrandCommand(id, request);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var command = new DeleteBrandCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> Restore(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var command = new RestoreBrandCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }
    }
}
