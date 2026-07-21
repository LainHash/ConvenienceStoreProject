using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Repositories.Catalog;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Repositories.Catalog
{
    internal class ProductRepository(ConvenienceStoreDbContext context) : Repository<Product>(context), IProductRepository
    {
        private readonly ConvenienceStoreDbContext _context = context;

        public async Task<Product?> FindAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.PublicId == id, cancellationToken);
        }
    }
}
