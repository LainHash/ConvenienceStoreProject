using ConvenienceStore.Application.Features.Authentication.Roles.Commands.Create;
using ConvenienceStore.Application.Features.Authentication.Roles.Commands.Delete;
using ConvenienceStore.Application.Features.Authentication.Roles.Commands.Restore;
using ConvenienceStore.Application.Features.Authentication.Roles.Commands.Update;
using ConvenienceStore.Application.Features.Authentication.Roles.Queries.GetAll;
using ConvenienceStore.Application.Features.Authentication.Roles.Queries.GetById;
using ConvenienceStore.Contract.DTOs.Identity.Roles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllRolesQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var query = new GetRoleByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateRoleRequest body,
            CancellationToken cancellationToken)
        {
            var command = new CreateRoleCommand(body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] string id,
            [FromBody] UpdateRoleRequest body,
            CancellationToken cancellationToken)
        {
            var command = new UpdateRoleCommand(id, body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var command = new DeleteRoleCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{id}/restore")]
        public async Task<IActionResult> Restore(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var command = new RestoreRoleCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
