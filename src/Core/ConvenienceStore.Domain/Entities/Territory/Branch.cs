using ConvenienceStore.Domain.Abstraction;

namespace ConvenienceStore.Domain.Entities.Territory
{
    public class Branch : SoftDeletableEntity
    {
        public string Country { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string? Description { get; private set; }
    }
}
