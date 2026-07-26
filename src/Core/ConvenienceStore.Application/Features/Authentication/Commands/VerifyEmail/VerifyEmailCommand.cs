using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Authentication;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Commands.VerifyEmail
{
    public record VerifyEmailCommand(VerifyEmailRequest Body)
        : IRequest<Result<object>>
    {
    }
}
