using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Repositories.CartAndWishlist;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.CartAndWishlist
{
    internal class CartItemRepository(ConvenienceStoreDbContext context)
        : Repository<CartItem>(context), ICartItemRepository
    {
    }
}
