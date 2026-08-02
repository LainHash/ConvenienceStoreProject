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
            await SeedAsync<ProductPriceSeeder>(_context);
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
            var tablesWithId = _context.Model
                .GetEntityTypes()
                .Select(e => e.GetTableName())
                .Where(t => t is not null)
                .Distinct()
                .ToList();

            foreach (var tableName in tablesWithId)
            {
                var sql = $"""
                    DO $$
                    BEGIN
                        IF EXISTS (
                            SELECT 1 FROM pg_class c
                            JOIN pg_namespace n ON n.oid = c.relnamespace
                            WHERE c.relkind = 'r'
                              AND c.relname = '{tableName}'
                        ) THEN
                            PERFORM setval(
                                pg_get_serial_sequence('"{tableName}"', 'Id'),
                                COALESCE((SELECT MAX("Id") FROM "{tableName}"), 0) + 1,
                                false
                            );
                        END IF;
                    END $$;
                    """;

                try
                {
                    await _context.Database.ExecuteSqlRawAsync(sql);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SyncSequence] Skipped \"{tableName}\": {ex.Message}");
                }
            }
        }
    }
}
