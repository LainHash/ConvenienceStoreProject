using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Identity;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Repositories.Identity
{
    internal class UserRepository(ConvenienceStoreDbContext context)
        : Repository<User>(context), IUserRepository
    {
        private readonly ConvenienceStoreDbContext _context = context;

        public async Task<bool> AnyAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.AnyAsync(x => string.Equals(x.PublicId, id), cancellationToken);
        }

        public async Task<User?> FindAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(x => string.Equals(x.PublicId, id), cancellationToken);
        }

        public async Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(x => string.Equals(x.Email, email), cancellationToken);
        }

        public async Task<User?> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(x => string.Equals(x.UserName, name), cancellationToken);
        }
    }
}
