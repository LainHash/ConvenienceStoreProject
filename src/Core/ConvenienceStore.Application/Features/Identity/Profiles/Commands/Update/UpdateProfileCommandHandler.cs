using ConvenienceStore.Application.Models.Results;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Contract.DTOs.Identity.Profiles;
using MediatR;

namespace ConvenienceStore.Application.Features.Identity.Profiles.Commands.Update
{
    internal class UpdateProfileCommandHandler(IProfileService profileService)
                : IRequestHandler<UpdateProfileCommand, Result<ProfileResponse>>
    {
        private readonly IProfileService _profileService = profileService;

        public async Task<Result<ProfileResponse>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateProfileSpecification(request);
            var response = await _profileService.UpdateAsync(specification, cancellationToken);
            return response;
        }
    }
}
