using ConvenienceStore.Domain.Entities.Guest;

namespace ConvenienceStore.Domain.Repositories.Guest
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer?> FindByUserAsync(int id, CancellationToken cancellationToken);
        Task<Customer?> FindAsync(string id, CancellationToken cancellationToken);
    }
}
