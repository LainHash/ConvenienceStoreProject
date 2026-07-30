using ConvenienceStore.Application.Features.Identity.Profiles.Commands.Update;
using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Contract.DTOs.Identity.Profiles;

namespace ConvenienceStore.Application.Services.Identity
{
    public interface IProfileService
    {
        Task<Result<ProfileResponse>> UpdateAsync(
            UpdateProfileSpecification specification,
            CancellationToken cancellationToken);
    }
}
