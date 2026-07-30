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
    }
}
