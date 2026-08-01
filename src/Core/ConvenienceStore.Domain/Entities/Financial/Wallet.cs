using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Guest;

namespace ConvenienceStore.Domain.Entities.Financial
{
    public partial class Wallet : SoftDeletableEntity
    {
        public int CustomerId { get; private set; }

        public decimal Balance { get; private set; }

        public bool IsLocked { get; private set; }

        public Customer Customer { get; private set; } = null!;

        public ICollection<WalletTransaction> Transactions { get; private set; } = [];
    }

    public partial class Wallet
    {
        public Wallet(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
