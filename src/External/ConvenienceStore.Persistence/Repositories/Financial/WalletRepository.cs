using ConvenienceStore.Domain.Entities.Financial;
using ConvenienceStore.Domain.Repositories.Financial;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Financial
{
    internal class WalletRepository(ConvenienceStoreDbContext context) 
        : Repository<Wallet>(context), IWalletRepository
    {
    }
}
