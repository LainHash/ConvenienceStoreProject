using ConvenienceStore.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConvenienceStore.Persistence.Configurations.Inventory
{
    internal class ProductStockConfiguration
        : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.ToTable("ProductStocks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityByDefaultColumn();

            builder.Property(x => x.PublicId)
                .IsRequired();

            builder.Property(x => x.Unit)
                .IsRequired();

            builder.Property(x => x.QuantityOnHand)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductStocks)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Branch)
                .WithMany(x => x.ProductStocks)
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
