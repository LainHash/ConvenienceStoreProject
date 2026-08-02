using ConvenienceStore.API.Extensions;
using ConvenienceStore.Application.Features.Guest.Customers.Queries.GetAll;
using ConvenienceStore.Application.Features.Guest.Customers.Queries.GetById;
using ConvenienceStore.Application.Features.Identity.Profiles.Commands.Update;
using ConvenienceStore.Application.Features.Identity.Users.Commands.Update;
using ConvenienceStore.Contract.DTOs.Identity.Profiles;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Guest
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllCustomersQuery query,
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
            var query = new GetCustomerByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPatch("profile/{id}")]
        public async Task<IActionResult> UpdateProfile(
            [FromRoute] string id,
            [FromBody] UpdateProfileRequest body,
            CancellationToken cancellationToken)
        {
            var command = new UpdateProfileCommand(id, body);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPatch("user/{id}")]
        public async Task<IActionResult> UpdateUser(
            [FromRoute] string id,
            [FromBody] UpdateUserRequest body,
            CancellationToken cancellationToken)
        {
            var command = new UpdateUserCommand(id, body);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }
    }
}
