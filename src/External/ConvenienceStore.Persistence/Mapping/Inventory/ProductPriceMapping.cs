using AutoMapper;
using ConvenienceStore.Domain.Entities.Inventory;
using ConvenienceStore.Persistence.DataRecords.Inventory;

namespace ConvenienceStore.Persistence.Mapping.Inventory
{
    internal class ProductPriceMapping : Profile
    {
        public ProductPriceMapping()
        {
            CreateMap<ProductPriceRecord, ProductPrice>().ReverseMap();
        }
    }
}
