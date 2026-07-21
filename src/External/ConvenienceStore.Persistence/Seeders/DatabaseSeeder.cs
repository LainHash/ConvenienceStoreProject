using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.Seeders.Catalog;
using ConvenienceStore.Persistence.Seeders.Inventory;
using Microsoft.Extensions.DependencyInjection;

namespace ConvenienceStore.Persistence.Seeders
{
    internal class DataSeeder
    {
        private readonly ConvenienceStoreDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public DataSeeder(IServiceProvider serviceProvider, ConvenienceStoreDbContext context)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }

        public async Task SeedAllAsync()
        {
            await SeedAsync<CategorySeeder>(_context);
            await SeedAsync<BrandSeeder>(_context);
            await SeedAsync<ProductSeeder>(_context);
            await SeedAsync<ProductStockSeeder>(_context);
        }

        private async Task SeedAsync<TSeeder>(ConvenienceStoreDbContext context) where TSeeder : IDataSeeder
        {
            using var scope = _serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<TSeeder>();
            await seeder.SeedAsync(context);
        }
    }
}
