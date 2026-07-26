using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Identity;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Repositories.Identity
{
    internal class RoleRepository(ConvenienceStoreDbContext context)
        : Repository<Role>(context), IRoleRepository
    {
        private readonly ConvenienceStoreDbContext _context = context;

        public async Task<Role?> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => string.Equals(x.Id, id), cancellationToken);
        }

        public async Task<Role?> FindAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => string.Equals(x.PublicId, id), cancellationToken);
        }

        public async Task<Role?> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => string.Equals(x.Name, name), cancellationToken);
        }
    }
}
