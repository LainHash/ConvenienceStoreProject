using ConvenienceStore.Application.Services.Business;
using ConvenienceStore.Application.Services.Catalog;
using ConvenienceStore.Domain.Repositories;
using ConvenienceStore.Persistence.Context;
using ConvenienceStore.Persistence.Repositories;
using ConvenienceStore.Persistence.Repositories.Catalog;
using ConvenienceStore.Persistence.Seeders;
using ConvenienceStore.Persistence.Services.Business;
using ConvenienceStore.Persistence.Services.Catalog;
using ConvenienceStore.Application.Services.Territory;
using ConvenienceStore.Persistence.Services.Territory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConvenienceStore.Application.Services.Storage;
using ConvenienceStore.Persistence.Services.Storage;
using ConvenienceStore.Application.Services.Authentication;
using ConvenienceStore.Application.Services.Identity;
using ConvenienceStore.Persistence.Services.Authentication;
using ConvenienceStore.Persistence.Services.Identity;
using ConvenienceStore.Application.Services.Guest;
using ConvenienceStore.Persistence.Services.Guest;

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

            // ── Repositories ─────────────────────────────────────────────────
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            var assembly = typeof(CategoryRepository).Assembly;

            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsClass || type.IsAbstract)
                    continue;

                if (!type.Name.EndsWith("Repository"))
                    continue;

                foreach (var iface in type.GetInterfaces())
                {
                    if (iface.Name.EndsWith("Repository"))
                    {
                        services.AddScoped(iface, type);
                    }
                }
            }

            // ── Services ─────────────────────────────────────────────────────
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IDataImporter, ExcelImporter>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IBranchService, BranchService>();

            services.AddScoped<IImageService, ImageService>();

            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<ICustomerService, CustomerService>();

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
