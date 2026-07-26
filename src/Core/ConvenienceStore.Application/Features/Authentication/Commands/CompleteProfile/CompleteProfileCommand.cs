using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Authentication;
using MediatR;

namespace ConvenienceStore.Application.Features.Authentication.Commands.CompleteProfile
{
    public record CompleteProfileCommand(CompleteProfileRequest Body)
        : IRequest<Result<object>>
    {
    }
}
