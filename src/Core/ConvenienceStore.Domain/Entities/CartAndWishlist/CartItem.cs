using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Entities.CartAndWishlist
{
    public class CartItem : AuditableEntity
    {
        public int Quantity { get; private set; }

        public int ProductId { get; private set; }
        public int CartId { get; private set; }

        public Product Product { get; private set; } = null!;
        public Cart Cart { get; private set; } = null!;
    }
}
