using AutoMapper;
using ConvenienceStore.Contract.DTOs.Catalog.Products;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Persistence.DataRecords.Catalog;
using Microsoft.EntityFrameworkCore.Query.Internal;

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
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.ProductStock.UnitPrice))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.ProductStock.Unit))
                .ForMember(dest => dest.QuantityOnHand, opt => opt.MapFrom(src => src.ProductStock.QuantityOnHand));

            CreateMap<CreateProductRequest, Product>()
                .ForPath(dest => dest.ProductStock.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForPath(dest => dest.ProductStock.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForPath(dest => dest.ProductStock.QuantityOnHand, opt => opt.MapFrom(src => src.QuantityOnHand))
                .ForPath(dest => dest.CategoryId, opt => opt.Ignore())
                .ForPath(dest => dest.BrandId, opt => opt.Ignore());

            CreateMap<UpdateProductRequest, Product>()
                .ForPath(dest => dest.ProductStock.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForPath(dest => dest.ProductStock.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForPath(dest => dest.ProductStock.QuantityOnHand, opt => opt.MapFrom(src => src.QuantityOnHand))
                .ForPath(dest => dest.CategoryId, opt => opt.Ignore())
                .ForPath(dest => dest.BrandId, opt => opt.Ignore());
        }
    }
}
