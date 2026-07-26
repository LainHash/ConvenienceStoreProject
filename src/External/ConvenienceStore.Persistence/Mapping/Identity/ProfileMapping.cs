using AutoMapper;
using ConvenienceStore.Contract.DTOs.Authentication;

namespace ConvenienceStore.Persistence.Mapping.Identity
{
    internal class ProfileMapping : AutoMapper.Profile
    {
        public ProfileMapping()
        {
            CreateMap<CompleteProfileRequest, Profile>();
        }
    }
}
