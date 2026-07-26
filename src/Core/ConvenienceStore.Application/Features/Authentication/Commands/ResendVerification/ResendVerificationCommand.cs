using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Authentication;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Commands.ResendVerification
{
    public record ResendVerificationCommand(ResendVerificationRequest Body)
        : IRequest<Result<object>>
    {
    }
}
