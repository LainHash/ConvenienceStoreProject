using AutoMapper;
using ConvenienceStore.Contract.DTOs.Authentication;
using ConvenienceStore.Domain.Entities.Identity;

namespace ConvenienceStore.Persistence.Mapping.Identity
{
    internal class UserMapping : AutoMapper.Profile
    {
        public UserMapping()
        {
            CreateMap<RegisterRequest, User>();
        }
    }
}
