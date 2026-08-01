using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.CartAndWishlist;
using ConvenienceStore.Domain.Entities.Financial;
using ConvenienceStore.Domain.Entities.Identity;

namespace ConvenienceStore.Domain.Entities.Guest
{
    public partial class Customer : SoftDeletableEntity
    {
        public int UserId { get; private set; }
        public int? ProfileId { get; private set; }

        public User User { get; private set; } = null!;
        public Profile? Profile { get; private set; } = null!;
        public Cart? Cart { get; private set; }
        public Wishlist? Wishlist { get; private set; }

        public Wallet? Wallet { get; private set; } = null!;
        public ICollection<Invoice> Invoices { get; private set; } = [];
    }

    public partial class Customer
    {
        public Customer() { }

        public Customer(int userId)
        {
            UserId = userId;
        }

        public void CompleteProfile(int profileId)
        {
            ProfileId = profileId;
        }
    }
}
