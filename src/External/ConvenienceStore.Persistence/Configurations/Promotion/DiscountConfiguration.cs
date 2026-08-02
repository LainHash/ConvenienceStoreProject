using ConvenienceStore.Domain.Entities.Promotion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConvenienceStore.Persistence.Configurations.Promotion
{
    internal class DiscountConfiguration
        : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discounts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityByDefaultColumn();

            builder.Property(x => x.PublicId)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.Value)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.MaximumDiscountAmount)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.MinimumOrderAmount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
