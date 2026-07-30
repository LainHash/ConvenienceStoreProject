using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Profiles;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Profiles.Commands.Update
{
    public record UpdateProfileCommand(string Id, UpdateProfileRequest Body)
        : IRequest<Result<ProfileResponse>>
    {
    }
}
