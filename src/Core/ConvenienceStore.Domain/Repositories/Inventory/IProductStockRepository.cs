using ConvenienceStore.Domain.Entities.Inventory;

namespace ConvenienceStore.Domain.Repositories.Inventory
{
    public interface IProductStockRepository : IRepository<ProductStock>
    {
        Task<ProductStock?> FindByProductAsync(
            int productId,
            CancellationToken cancellationToken = default);
    }
}
