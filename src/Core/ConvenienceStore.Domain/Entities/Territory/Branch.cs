using ConvenienceStore.Domain.Abstraction;

namespace ConvenienceStore.Domain.Entities.Territory
{
    public class Branch : SoftDeletableEntity
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
