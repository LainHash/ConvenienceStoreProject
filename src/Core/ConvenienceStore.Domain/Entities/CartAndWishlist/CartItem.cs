using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Entities.CartAndWishlist
{
    public partial class CartItem : AuditableEntity
    {
        public int Quantity { get; private set; }

        public int ProductId { get; private set; }
        public int CartId { get; private set; }

        public Product Product { get; private set; } = null!;
        public Cart Cart { get; private set; } = null!;
    }

    public partial class CartItem
    {
        public CartItem() { }

        public CartItem(int productId)
        {
            ProductId = productId;
            IncreaseQuantity();
        }

        public void IncreaseQuantity(int amount = 1)
        {
            Quantity += amount;
        }
    }
}
