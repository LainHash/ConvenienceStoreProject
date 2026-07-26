using ConvenienceStore.Domain.Entities.Identity;

namespace ConvenienceStore.Domain.Repositories.Identity
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> FindAsync(string id, CancellationToken cancellationToken = default);
        Task<User?> FindByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
