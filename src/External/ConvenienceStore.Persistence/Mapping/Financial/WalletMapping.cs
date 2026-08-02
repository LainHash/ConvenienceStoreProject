using AutoMapper;
using ConvenienceStore.Contract.DTOs.Financial;
using ConvenienceStore.Domain.Entities.Guest;

namespace ConvenienceStore.Persistence.Mapping.Financial
{
    internal class WalletMapping : Profile
    {
        public WalletMapping()
        {
            CreateMap<Wallet, WalletResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId));
        }
    }
}
