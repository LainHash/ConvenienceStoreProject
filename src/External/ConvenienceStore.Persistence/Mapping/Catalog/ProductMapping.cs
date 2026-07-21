using AutoMapper;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Persistence.Mapping.Catalog
{
    internal class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.ProductStock.UnitPrice))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.ProductStock.Unit))
                .ForMember(dest => dest.QuantityOnHand, opt => opt.MapFrom(src => src.ProductStock.QuantityOnHand));
        }
    }
}
