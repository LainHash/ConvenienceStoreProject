using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Domain.Repositories.Storage;
using ConvenienceStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ConvenienceStore.Persistence.Repositories.Storage
{
    internal class ImageRepository(ConvenienceStoreDbContext context)
        : Repository<Image>(context), IImageRepository
    {
    }
}
