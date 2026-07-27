using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Repositories.CartAndWishlist;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.CartAndWishlist
{
    internal class CartRepository(ConvenienceStoreDbContext context) 
        : Repository<Cart>(context), ICartRepository
    {
    }
}
