using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Repositories.Catalog;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Repositories.Catalog
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ConvenienceStoreDbContext _context;
        public CategoryRepository(ConvenienceStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category?> FindNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(x => string.Equals(x.Name, name), cancellationToken);
        }

        public async Task<Category?> FindAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => string.Equals(x.PublicId, id), cancellationToken);
        }
    }
}
