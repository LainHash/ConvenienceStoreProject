using ConvenienceStore.Contract.DTOs.Authentication;
using ConvenienceStore.Contract.DTOs.Identity.Profiles;
using ConvenienceStore.Domain.Entities.Identity;

namespace ConvenienceStore.Persistence.Mapping.Identity
{
    internal class ProfileMapping : AutoMapper.Profile
    {
        public ProfileMapping()
        {
            CreateMap<CompleteProfileRequest, Profile>();

            CreateMap<Profile, ProfileResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId));
        }
    }
}
