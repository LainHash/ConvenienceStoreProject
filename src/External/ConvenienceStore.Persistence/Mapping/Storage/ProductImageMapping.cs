using AutoMapper;
using ConvenienceStore.Contract.DTOs.Storage.Images;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Persistence.DataRecords.Storage;

namespace ConvenienceStore.Persistence.Mapping.Storage
{
    internal class ProductImageMapping : Profile
    {
        public ProductImageMapping()
        {
            CreateMap<ProductImageRecord, ProductImage>().ReverseMap();

            CreateMap<ProductImage, ImageResponse>()
                .ForMember(dest => dest.DisplayOrder, opt => opt.MapFrom(src => src.DisplayOrder))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Image.PublicId))
                .ForMember(dest => dest.AltText, opt => opt.MapFrom(src => src.Image.AltText))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Image.Url));
        }
    }
}
