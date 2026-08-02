using ConvenienceStore.API.Extensions;
using ConvenienceStore.Application.Features.Authentication.Commands.CompleteProfile;
using ConvenienceStore.Application.Features.Authentication.Commands.Login;
using ConvenienceStore.Application.Features.Authentication.Commands.Register;
using ConvenienceStore.Application.Features.Authentication.Commands.ResendVerification;
using ConvenienceStore.Application.Features.Authentication.Commands.VerifyEmail;
using ConvenienceStore.Contract.DTOs.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConvenienceStore.API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("/login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest body,
            CancellationToken cancellationToken)
        {
            var command = new LoginCommand(body);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterRequest request,
            CancellationToken cancellationToken)
        {
            var command = new RegisterCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost("/complete-profile")]
        public async Task<IActionResult> CompleteProfile(
            [FromBody] CompleteProfileRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CompleteProfileCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost("/verify-email")]
        public async Task<IActionResult> VerifyEmail(
            [FromBody] VerifyEmailRequest request,
            CancellationToken cancellationToken)
        {
            var command = new VerifyEmailCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }

        [HttpPost("/resend-verification")]
        public async Task<IActionResult> ResendVerification(
            [FromBody] ResendVerificationRequest body,
            CancellationToken cancellationToken)
        {
            var command = new ResendVerificationCommand(body);
            var result = await _mediator.Send(command, cancellationToken);
            return this.ToActionResult(result);
        }
    }
}
