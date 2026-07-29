using ConvenienceStore.Domain.Entities.Inventory;
using ConvenienceStore.Domain.Repositories.Inventory;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Repositories.Inventory
{
    internal class ProductStockRepository(ConvenienceStoreDbContext context)
        : Repository<ProductStock>(context), IProductStockRepository
    {
        private readonly ConvenienceStoreDbContext _context = context;
        public async Task<ProductStock?> FindByProductAsync(int productId, CancellationToken cancellationToken = default)
        {
            return await _context.ProductStocks.FirstOrDefaultAsync(x => x.ProductId == productId, cancellationToken);
        }
    }
}
