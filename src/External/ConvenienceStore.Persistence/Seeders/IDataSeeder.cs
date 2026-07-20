using ConvenienceStore.Persistence.Context;

namespace ConvenienceStore.Persistence.Seeders
{
    internal interface IDataSeeder
    {
        Task SeedAsync(ConvenienceStoreDbContext context);
    }
}
