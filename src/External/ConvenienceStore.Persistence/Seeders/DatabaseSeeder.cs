using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.Seeders.Catalog;
using ConvenienceStore.Persistence.Seeders.Inventory;
using ConvenienceStore.Persistence.Seeders.Storage;
using Microsoft.EntityFrameworkCore;
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

            await SeedAsync<ImageSeeder>(_context);
            await SeedAsync<ProductImageSeeder>(_context);

            await SyncPostgresSequencesAsync();
        }

        private async Task SeedAsync<TSeeder>(ConvenienceStoreDbContext context) where TSeeder : IDataSeeder
        {
            using var scope = _serviceProvider.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<TSeeder>();
            await seeder.SeedAsync(context);
        }

        private async Task SyncPostgresSequencesAsync()
        {
            var tables = new[] { "Categories", "Brands", "Products", "ProductStocks", "Branches" };
            foreach (var table in tables)
            {
                var sql = $@"
                    DO $$ 
                    BEGIN 
                        IF EXISTS (SELECT FROM pg_tables WHERE tablename  = '{table.ToLower()}') OR EXISTS (SELECT FROM pg_tables WHERE tablename  = '{table}') THEN 
                            PERFORM setval(pg_get_serial_sequence('""{table}""', 'Id'), coalesce(max(""Id""), 0) + 1, false) FROM ""{table}""; 
                        END IF; 
                    END $$;";
                try
                {
                    await _context.Database.ExecuteSqlRawAsync(sql);
                }
                catch
                {
                    // Ignore if sequence doesn't exist
                }
            }
        }
    }
}
