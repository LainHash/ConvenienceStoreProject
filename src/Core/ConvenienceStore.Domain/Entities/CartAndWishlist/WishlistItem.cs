using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Entities.CartAndWishlist
{
    public class WishlistItem : AuditableEntity
    {
        public int ProductId { get; private set; }
        public int WishlistId { get; private set; }

        public Product Product { get; private set; } = null!;
        public Wishlist Wishlist { get; private set; } = null!;
    }
}
