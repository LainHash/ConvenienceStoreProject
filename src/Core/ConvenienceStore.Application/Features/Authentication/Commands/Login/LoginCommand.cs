using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Authentication;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Commands.Login
{
    public record LoginCommand(LoginRequest Body)
        : IRequest<Result<AuthenticationResponse>>
    {
    }
}
