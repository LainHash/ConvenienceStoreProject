using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Guest;

namespace ConvenienceStore.Domain.Entities.CartAndWishlist
{
    public partial class Wishlist : AuditableEntity
    {
        public int? CustomerId { get; private set; }
        public string? SessionId { get; private set; }

        public Customer Customer { get; private set; } = null!;
        public ICollection<WishlistItem> WishlistItems { get; private set; } = [];
    }

    public partial class Wishlist
    {
        public Wishlist() { }

        public Wishlist(int customerId)
        {
            CustomerId = customerId;
        }

        public Wishlist(string sessionId)
        {
            SessionId = sessionId;
        }
    }
}
