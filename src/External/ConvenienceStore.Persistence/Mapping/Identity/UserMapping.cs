using ConvenienceStore.Contract.DTOs.Authentication;
using ConvenienceStore.Contract.DTOs.Identity.Users;
using ConvenienceStore.Domain.Entities.Identity;

namespace ConvenienceStore.Persistence.Mapping.Identity
{
    internal class UserMapping : AutoMapper.Profile
    {
        public UserMapping()
        {
            CreateMap<RegisterRequest, User>();

            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}
