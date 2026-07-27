using ConvenienceStore.Domain.Entities.CartAndWishlist;

namespace ConvenienceStore.Domain.Repositories.CartAndWishlist
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart?> FindByCustomerAsync(int customerId, CancellationToken cancellationToken = default);
    }
}
