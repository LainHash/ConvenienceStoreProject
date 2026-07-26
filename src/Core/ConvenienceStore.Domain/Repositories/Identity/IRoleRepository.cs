using ConvenienceStore.Domain.Entities.Identity;

namespace ConvenienceStore.Domain.Repositories.Identity
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role?> FindAsync(int id, CancellationToken cancellationToken = default);
        Task<Role?> FindAsync(string id, CancellationToken cancellationToken = default);
        Task<Role?> FindByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
