using ConvenienceStore.Domain.Entities.Storage;

namespace ConvenienceStore.Domain.Repositories.Storage
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        Task<int> CountByProductIdAsync(int productId, CancellationToken cancellationToken = default);

        Task UnsetPrimaryAsync(int productId, CancellationToken cancellationToken = default);
    }
}
