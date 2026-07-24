using ConvenienceStore.Application.Features.Catalog.Products.Commands.Create;
using ConvenienceStore.Application.Features.Catalog.Products.Commands.Delete;
using ConvenienceStore.Application.Features.Catalog.Products.Commands.Restore;
using ConvenienceStore.Application.Features.Catalog.Products.Commands.Update;
using ConvenienceStore.Application.Features.Catalog.Products.Queries.GetAll;
using ConvenienceStore.Application.Features.Catalog.Products.Queries.GetById;
using ConvenienceStore.Application.Features.Storage.Images.Commands.Upload;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using ConvenienceStore.Contract.DTOs.Storage.Images;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Catalog
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllProductQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery(id);
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductRequest body,
            CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand(body);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] string id,
            [FromBody] UpdateProductRequest body,
            CancellationToken cancellationToken)
        {
            var command = new UpdateProductCommand(id, body);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand(id);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> Restore(string id, CancellationToken cancellationToken)
        {
            var command = new RestoreProductCommand(id);
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{id}/images")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage(
            [FromRoute] string id,
            IFormFile file,
            [FromForm] UploadImageRequest metadata,
            CancellationToken cancellationToken)
        {
            if (file is null || file.Length == 0)
                return BadRequest("File ảnh không được để trống.");

            await using var stream = file.OpenReadStream();

            var command = new UploadProductImageCommand(id, stream, file.FileName, metadata);

            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
