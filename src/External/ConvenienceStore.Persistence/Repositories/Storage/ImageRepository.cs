using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Domain.Repositories.Storage;
using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Repositories.Storage
{
    internal class ImageRepository(ConvenienceStoreDbContext context) 
        : Repository<Image>(context), IImageRepository
    {
    }
}
