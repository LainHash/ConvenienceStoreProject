using ConvenienceStore.Domain.Entities.Sale;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConvenienceStore.Persistence.Configurations.Sale
{
    internal class InvoiceConfiguration
        : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityByDefaultColumn();

            builder.Property(x => x.PublicId)
                .IsRequired();

            builder.Property(x => x.InvoiceNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(x => x.InvoiceNumber)
                .IsUnique();

            builder.Property(x => x.Subtotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.DiscountAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0m);

            builder.Property(x => x.ShippingFee)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0m);

            builder.Property(x => x.Tax)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0m);

            builder.Property(x => x.TotalAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.Note)
                .HasMaxLength(500);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasOne(x => x.Discount)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.DiscountId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
