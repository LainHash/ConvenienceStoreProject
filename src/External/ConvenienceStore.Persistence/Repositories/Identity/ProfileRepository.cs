using ConvenienceStore.Domain.Entities.Identity;
using ConvenienceStore.Domain.Repositories.Identity;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Identity
{
    internal class ProfileRepository(ConvenienceStoreDbContext context)
                : Repository<Profile>(context), IProfileRepository
    {
    }
}
