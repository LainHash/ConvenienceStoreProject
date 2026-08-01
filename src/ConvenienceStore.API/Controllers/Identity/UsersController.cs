using ConvenienceStore.Application.Features.Identity.Users.Commands.ChangePassword;
using ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmEmailChange;
using ConvenienceStore.Application.Features.Identity.Users.Commands.RequestEmailChange;
using ConvenienceStore.Application.Features.Identity.Users.Commands.Update;
using ConvenienceStore.Application.Features.Identity.Users.Queries.GetAll;
using ConvenienceStore.Application.Features.Identity.Users.Queries.GetById;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ConvenienceStore.API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllUsersQuery query,
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
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] string id,
            [FromBody] UpdateUserRequest body,
            CancellationToken cancellationToken)
        {
            var command = new UpdateUserCommand(id, body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{id}/change-password")]
        public async Task<IActionResult> ChangePassword(
            [FromRoute] string id,
            [FromBody] ChangeUserPasswordRequest body,
            CancellationToken cancellationToken)
        {
            var command = new ChangeUserPasswordCommand(id, body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{id}/request-email-change")]
        public async Task<IActionResult> RequestEmailChange(
            [FromRoute] string id,
            [FromBody] RequestEmailChangeRequest body,
            CancellationToken cancellationToken)
        {
            var command = new RequestEmailChangeCommand(id, body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{id}/confirm-current-email-change")]
        public async Task<IActionResult> ConfirmCurrentEmailChange(
            [FromRoute] string id,
            [FromBody] ConfirmEmailChangeRequest body,
            CancellationToken cancellationToken)
        {
            var command = new ConvenienceStore.Application.Features.Identity.Users.Commands.ConfirmCurrentEmailChange.ConfirmCurrentEmailChangeCommand(id, body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{id}/confirm-email-change")]
        public async Task<IActionResult> ConfirmEmailChange(
            [FromRoute] string id,
            [FromBody] ConfirmEmailChangeRequest body,
            CancellationToken cancellationToken)
        {
            var command = new ConfirmEmailChangeCommand(id, body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
