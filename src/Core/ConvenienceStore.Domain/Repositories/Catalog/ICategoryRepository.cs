using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Repositories.Catalog
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> FindNameAsync(string name, CancellationToken cancellationToken = default);
        Task<Category?> FindAsync(string id, CancellationToken cancellationToken = default);
    }
}
