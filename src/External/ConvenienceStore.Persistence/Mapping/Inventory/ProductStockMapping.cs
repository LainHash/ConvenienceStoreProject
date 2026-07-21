using AutoMapper;
using ConvenienceStore.Domain.Entities.Inventory;
using ConvenienceStore.Persistence.DataRecords.Inventory;

namespace ConvenienceStore.Persistence.Mapping.Inventory
{
    internal class ProductStockMapping : Profile
    {
        public ProductStockMapping()
        {
            CreateMap<ProductStockRecord, ProductStock>().ReverseMap();
        }
    }
}
