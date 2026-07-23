using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Entities.Inventory;
using ConvenienceStore.Domain.Entities.Storage;
using ConvenienceStore.Domain.Entities.Territory;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConvenienceStore.Persistence.Context
{
    internal class ConvenienceStoreDbContext : DbContext
    {
        public ConvenienceStoreDbContext(DbContextOptions<ConvenienceStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductStock> ProductStocks { get; set; } = null!;

        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<ProductImage> ProductImages { get; set; } = null!;

        public DbSet<Branch> Branches { get; set; } = null!;

        // ── Model building ──────────────────────────────────────────────────
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Auto-register all IEntityTypeConfiguration<T> classes in this assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        // ── Auto-set audit fields on SaveChanges ────────────────────────────
        public override int SaveChanges()
        {
            SetAuditFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditFields()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.MarkCreated(now);
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.MarkUpdated(now);
                }
            }
        }
    }
}
