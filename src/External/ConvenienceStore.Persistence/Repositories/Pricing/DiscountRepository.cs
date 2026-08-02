using ConvenienceStore.Domain.Entities.Pricing;
using ConvenienceStore.Domain.Repositories.Pricing;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Pricing
{
    internal class DiscountRepository(ConvenienceStoreDbContext context) 
        : Repository<Discount>(context), IDiscountRepository
    {
    }
}
