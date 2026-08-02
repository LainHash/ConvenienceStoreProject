using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Repositories.Guest;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Guest
{
    internal class WalletRepository(ConvenienceStoreDbContext context) 
        : Repository<Wallet>(context), IWalletRepository
    {
    }
}
