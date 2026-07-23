using AutoMapper;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Persistence.DataRecords.Storage;

namespace ConvenienceStore.Persistence.Mapping.Storage
{
    internal class ProductImageMapping : Profile
    {
        public ProductImageMapping()
        {
            CreateMap<ProductImageRecord, ProductImage>().ReverseMap();
        }
    }
}
