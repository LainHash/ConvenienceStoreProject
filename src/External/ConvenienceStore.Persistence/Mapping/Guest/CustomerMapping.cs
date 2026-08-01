using AutoMapper;
using ConvenienceStore.Contract.DTOs.Guest.Customers;
using ConvenienceStore.Domain.Entities.Guest;

namespace ConvenienceStore.Persistence.Mapping.Guest
{
    internal class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customer, CustomerResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
                .ForMember(dest => dest.Wallet, opt => opt.MapFrom(src => src.Wallet));
        }
    }
}
