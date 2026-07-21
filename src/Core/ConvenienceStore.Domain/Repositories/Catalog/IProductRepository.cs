using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Repositories.Catalog
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> FindAsync(string id, CancellationToken cancellationToken = default);
    }
}
