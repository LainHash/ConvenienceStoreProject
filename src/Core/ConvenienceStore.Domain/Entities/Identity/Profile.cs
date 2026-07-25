using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Guest;

namespace ConvenienceStore.Domain.Entities.Identity
{
    public class Profile : SoftDeletableEntity
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public DateOnly Dob { get; private set; }
        public bool Gender { get; private set; }

        public string Address { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string Country { get; private set; } = string.Empty;

        public string Phone { get; private set; } = string.Empty;
        public string CitizenCardId { get; private set; } = string.Empty;

        public Customer Customer { get; private set; } = null!;
    }
}
