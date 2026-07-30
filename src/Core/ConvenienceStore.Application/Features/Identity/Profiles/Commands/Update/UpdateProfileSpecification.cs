using ConvenienceStore.Contract.DTOs.Identity.Profiles;
using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Application.Features.Identity.Profiles.Commands.Update
{
    public class UpdateProfileSpecification
        : BaseSpecification<Profile>
    {
        public UpdateProfileRequest Body { get; set; }
        public UpdateProfileSpecification(UpdateProfileCommand command)
        {
            Criteria = p => string.Equals(p.PublicId, command.Id);
            Body = command.Body;
        }
    }
}
