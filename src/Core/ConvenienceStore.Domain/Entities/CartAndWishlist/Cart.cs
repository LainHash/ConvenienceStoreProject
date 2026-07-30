using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Specifications;

namespace ConvenienceStore.Domain.Entities.CartAndWishlist
{
    public partial class Cart : AuditableEntity
    {
        public int? CustomerId { get; private set; }
        public string? SessionId { get; private set; }

        public Customer Customer { get; private set; } = null!;
        public ICollection<CartItem> CartItems { get; private set; } = [];
    }

    public partial class Cart
    {
        public Cart() { }

        public Cart(int customerId)
        {
            CustomerId = customerId;
        }

        public Cart(string sessionId)
        {
            SessionId = sessionId;
        }

        public void ChangeItemQuantity(string cartItemId, int amount, int availableStock)
        {
            var item = CartItems.First(x => string.Equals(x.PublicId, cartItemId));

            var newQuantity = item.Quantity + amount;

            if (newQuantity < 0)
            {
                throw new InvalidOperationException("Quantity can not be decreased below zero.");
            }

            if (newQuantity == 0)
            {
                CartItems.Remove(item);
                return;
            }

            if (newQuantity > availableStock)
            {
                throw new InvalidOperationException("Out of stock.");
            }

            item.SetQuantity(newQuantity);
        }
    }
}
