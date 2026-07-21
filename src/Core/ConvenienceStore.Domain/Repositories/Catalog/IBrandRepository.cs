using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Repositories.Catalog
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<Brand?> FindNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Brand?> FindAsync(string id, CancellationToken cancellationToken = default);
    }
}
