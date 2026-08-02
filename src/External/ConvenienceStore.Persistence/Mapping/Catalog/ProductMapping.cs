using AutoMapper;
using ConvenienceStore.Application.Extensions;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Persistence.DataRecords.Catalog;

namespace ConvenienceStore.Persistence.Mapping.Catalog
{
    internal class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductRecord, Product>().ReverseMap();

            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PublicId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.ProductPrice.UnitPrice))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ProductImages))
                .ForMember(dest => dest.PrimaryImage, opt => opt.MapFrom(src => src.ProductImages.FirstOrDefault(x => x.IsPrimary)));

            CreateMap<CreateProductRequest, Product>()
                .ForPath(dest => dest.ProductPrice.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForPath(dest => dest.CategoryId, opt => opt.Ignore())
                .ForPath(dest => dest.BrandId, opt => opt.Ignore());

            CreateMap<UpdateProductRequest, Product>()
                .ForPath(dest => dest.ProductPrice.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForPath(dest => dest.CategoryId, opt => opt.Ignore())
                .ForPath(dest => dest.BrandId, opt => opt.Ignore());
        }
    }
}
