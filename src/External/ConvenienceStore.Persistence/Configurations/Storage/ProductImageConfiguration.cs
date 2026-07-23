using ConvenienceStore.Domain.Entities.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConvenienceStore.Persistence.Configurations.Storage
{
    internal class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityByDefaultColumn();

            builder.HasOne(x => x.Image)
                   .WithMany(x => x.ProductImages)
                   .HasForeignKey(x => x.ImageId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.ProductId)
                    .IsUnique()
                    .HasFilter("\"IsPrimary\" = true");

        }
    }
}
