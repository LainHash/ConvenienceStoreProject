using ConvenienceStore.Application.Features.Financial.Wallets.Queries.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Financial
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("/api/Customers/user/{id}/wallet")]
        public async Task<IActionResult> GetByUser(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var query = new GetWalletByUserIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
