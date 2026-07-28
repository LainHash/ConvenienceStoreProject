using ConvenienceStore.Domain.Entities.CartAndWishlist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConvenienceStore.Persistence.Configurations.CartAndWishlist
{
    internal class CartItemConfiguration
        : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityByDefaultColumn();

            builder.Property(x => x.PublicId)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.CartItems)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
