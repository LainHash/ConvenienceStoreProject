using ConvenienceStore.Domain.Entities.Carts;
using ConvenienceStore.Domain.Repositories.Carts;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Carts
{
    internal class CartRepository(ConvenienceStoreDbContext context) 
        : Repository<Cart>(context), ICartRepository
    {
    }
}
