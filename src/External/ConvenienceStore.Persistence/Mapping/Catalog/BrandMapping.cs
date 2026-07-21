using AutoMapper;
using ConvenienceStore.Contract.DTOs.Catalog;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Persistence.DataRecords.Catalog;

namespace ConvenienceStore.Persistence.Mapping.Catalog
{
    internal class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<BrandRecord, Brand>().ReverseMap();
            CreateMap<Brand, BrandResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId));
            CreateMap<CreateBrandRequest, Brand>();
            CreateMap<UpdateBrandRequest, Brand>();
        }
    }
}
