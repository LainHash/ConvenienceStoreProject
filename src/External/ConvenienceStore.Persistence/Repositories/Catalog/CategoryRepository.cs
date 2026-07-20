using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Repositories.Catalog;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Catalog
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ConvenienceStoreDbContext context) : base(context)
        {
        }
    }
}
