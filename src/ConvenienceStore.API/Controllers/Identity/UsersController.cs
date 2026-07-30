using ConvenienceStore.Application.Features.Identity.Users.Queries.GetAll;
using ConvenienceStore.Application.Features.Identity.Users.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
