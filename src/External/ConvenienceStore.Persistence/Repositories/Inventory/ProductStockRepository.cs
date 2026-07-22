using ConvenienceStore.Domain.Entities.Inventory;
using ConvenienceStore.Domain.Repositories.Inventory;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Inventory
{
    internal class ProductStockRepository(ConvenienceStoreDbContext context) 
        : Repository<ProductStock>(context), IProductStockRepository
    {
    }
}
