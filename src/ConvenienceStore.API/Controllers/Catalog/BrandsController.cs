using ConvenienceStore.Application.Features.Catalog.Brands.Commands.Create;
using ConvenienceStore.Application.Features.Catalog.Brands.Commands.Delete;
using ConvenienceStore.Application.Features.Catalog.Brands.Commands.Restore;
using ConvenienceStore.Application.Features.Catalog.Brands.Commands.Update;
using ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Brands.Queries.GetById;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Catalog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Catalog
{
    [Route("api/catalog/[controller]")]
    [ApiController]
    public class BrandsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<BrandResponse>>>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllBrandsQuery();
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<BrandResponse>>> GetById(string id, CancellationToken cancellationToken)
        {
            var query = new GetBrandByIdQuery(id);
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<Result<BrandResponse>>> Create(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateBrandCommand(request);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<BrandResponse>>> Update(string id, UpdateBrandRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateBrandCommand(id, request);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<object>>> Delete(string id, CancellationToken cancellationToken)
        {
            var command = new DeleteBrandCommand(id);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("{id}/restore")]
        public async Task<ActionResult<Result<object>>> Restore(string id, CancellationToken cancellationToken)
        {
            var command = new RestoreBrandCommand(id);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
