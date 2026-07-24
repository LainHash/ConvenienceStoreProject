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

            builder.Property(x => x.UnitPrice)
                .HasColumnType("decimal(12,3)")
                .IsRequired();

            builder.Property(x => x.Unit)
                .IsRequired();

            builder.Property(x => x.QuantityOnHand)
                .IsRequired();
        }
    }
}
