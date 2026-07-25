using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Identity;

namespace ConvenienceStore.Domain.Entities.Guest
{
    public class Customer : SoftDeletableEntity
    {
        public int UserId { get; private set; }
        public int? ProfileId { get; private set; }

        public User User { get; private set; } = null!;
        public Profile? Profile { get; private set; } = null!;
    }
}
