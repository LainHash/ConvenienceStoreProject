using AutoMapper;
using ConvenienceStore.Contract.DTOs.Pricing.Discounts;
using ConvenienceStore.Domain.Entities.Pricing;

namespace ConvenienceStore.Persistence.Mapping.Pricing
{
    internal class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, DiscountResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId));
        }
    }
}
