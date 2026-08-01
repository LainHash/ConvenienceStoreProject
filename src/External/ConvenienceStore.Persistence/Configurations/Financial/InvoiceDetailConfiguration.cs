using ConvenienceStore.Domain.Entities.Financial;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConvenienceStore.Persistence.Configurations.Financial
{
    internal class InvoiceDetailConfiguration
        : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable("InvoiceDetails");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityByDefaultColumn();

            builder.Property(x => x.PublicId)
                .IsRequired();

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.Discount)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0m);

            builder.Property(x => x.LineTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(x => x.Invoice)
                .WithMany(x => x.InvoiceDetails)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.InvoiceDetails)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
