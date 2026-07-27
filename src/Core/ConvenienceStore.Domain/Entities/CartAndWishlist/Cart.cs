using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Guest;

namespace ConvenienceStore.Domain.Entities.CartAndWishlist
{
    public class Cart : AuditableEntity
    {
        public int CustomerId { get; private set; }

        public Customer Customer { get; private set; } = null!;
        public ICollection<CartItem> CartItems { get; private set; } = [];
    }
}
