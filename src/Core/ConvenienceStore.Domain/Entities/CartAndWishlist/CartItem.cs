using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Entities.CartAndWishlist
{
    public partial class CartItem : AuditableEntity
    {
        public int Quantity { get; private set; }

        public int ProductId { get; private set; }
        public int CartId { get; private set; }

        public uint Version { get; private set; }

        public Product Product { get; private set; } = null!;
        public Cart Cart { get; private set; } = null!;
    }

    public partial class CartItem
    {
        public CartItem() { }

        public CartItem(int productId)
        {
            ProductId = productId;
            ChangeQuantity();
        }

        public void ChangeQuantity(int amount = 1)
        {
            Quantity += amount;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
