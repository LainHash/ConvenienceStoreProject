using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Authentication;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Commands.Register
{
    public record RegisterCommand(RegisterRequest Body)
        : IRequest<Result<object>>
    {
    }
}
