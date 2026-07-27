using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Repositories.Guest;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Repositories.Guest
{
    internal class CustomerRepository(ConvenienceStoreDbContext context)
        : Repository<Customer>(context), ICustomerRepository
    {
        private readonly ConvenienceStoreDbContext _context = context;
        public async Task<Customer?> FindByUserAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
        }

        public async Task<Customer?> FindAsync(string id, CancellationToken cancellationToken)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.PublicId == id, cancellationToken);
        }
    }
}
