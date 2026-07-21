using ConvenienceStore.Domain.Entities.Territory;
using ConvenienceStore.Domain.Repositories.Territory;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Repositories.Territory
{
    internal class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private readonly ConvenienceStoreDbContext _context;
        public BranchRepository(ConvenienceStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Branch?> FindAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Branches.FirstOrDefaultAsync(x => string.Equals(x.PublicId, id), cancellationToken);
        }
    }
}
