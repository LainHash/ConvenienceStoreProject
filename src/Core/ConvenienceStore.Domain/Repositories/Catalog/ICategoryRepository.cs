using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Repositories.Catalog
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> FindAsync(string name, CancellationToken cancellationToken = default);
    }
}
