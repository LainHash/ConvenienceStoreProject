using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.Seeders;
using ConvenienceStore.Persistence.Services.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConvenienceStore.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // ── Database ─────────────────────────────────────────────────────
            services.AddDbContext<ConvenienceStoreDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("MyConnectString"),
                    sqlOptions => sqlOptions.MigrationsAssembly(
                        typeof(ConvenienceStoreDbContext).Assembly.FullName)));

            // ── Seeders ──────────────────────────────────────────────────────
            // Orchestrator seeder
            services.AddScoped<DataSeeder>();

            // Auto-register all IDataSeeder implementations
            var seederTypes = typeof(DependencyInjection).Assembly.GetTypes()
                .Where(t => typeof(IDataSeeder).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in seederTypes)
            {
                services.AddScoped(type);
            }

            // ── AutoMapper ───────────────────────────────────────────────────
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(DependencyInjection).Assembly));

            // ── Services ─────────────────────────────────────────────────────
            services.AddScoped<IDataImporter, ExcelImporter>();



            return services;
        }

        public static async Task InitialiseDatabaseAsync(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var sp = scope.ServiceProvider;

            var context = sp.GetRequiredService<ConvenienceStoreDbContext>();
            await context.Database.MigrateAsync();

            var seeder = sp.GetRequiredService<DataSeeder>();
            await seeder.SeedAllAsync();
        }
    }
}
