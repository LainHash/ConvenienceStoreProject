using ConvenienceStore.Contract.DTOs.Identity.Roles;
using ConvenienceStore.Domain.Entities.Identity;

namespace ConvenienceStore.Persistence.Mapping.Identity
{
    internal class RoleMapping : AutoMapper.Profile
    {
        public RoleMapping()
        {
            CreateMap<Role, RoleResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId));
            CreateMap<CreateRoleRequest, Role>();
            CreateMap<UpdateRoleRequest, Role>();
        }
    }
}
