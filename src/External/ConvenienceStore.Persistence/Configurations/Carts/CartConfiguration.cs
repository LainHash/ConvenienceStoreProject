using ConvenienceStore.Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConvenienceStore.Persistence.Configurations.Carts
{
    internal class CartConfiguration
        : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityByDefaultColumn();

            builder.Property(x => x.PublicId)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Cart)
                .HasForeignKey<Cart>(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
