using ConvenienceStore.Domain.Entities.Carts;
using ConvenienceStore.Domain.Repositories.Carts;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Carts
{
    internal class CartItemRepository(ConvenienceStoreDbContext context)
        : Repository<CartItem>(context), ICartItemRepository
    {
    }
}
