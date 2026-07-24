using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Repositories.Catalog;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Repositories.Catalog
{
    internal class BrandRepository(ConvenienceStoreDbContext context) : Repository<Brand>(context), IBrandRepository
    {
        private readonly ConvenienceStoreDbContext _context = context;

        public async Task<Brand?> FindNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Brand>()
                .FirstOrDefaultAsync(x => string.Equals(x.Name, name), cancellationToken);
        }

        public async Task<Brand?> FindAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Brand>().FirstOrDefaultAsync(x => string.Equals(x.PublicId, id), cancellationToken);
        }
    }
}
