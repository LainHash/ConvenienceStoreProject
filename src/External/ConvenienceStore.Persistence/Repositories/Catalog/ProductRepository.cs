using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Repositories.Catalog;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Catalog
{
    internal class ProductRepository : Repository<Product>, IProductRespository
    {
        public ProductRepository(ConvenienceStoreDbContext context) : base(context)
        {
        }
    }
}
