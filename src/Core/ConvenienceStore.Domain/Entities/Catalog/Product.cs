using ConvenienceStore.Domain.Abstraction;

namespace ConvenienceStore.Domain.Entities.Catalog
{
    public class Product : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public int CategoryId { get; private set; }
        public int BrandId { get; private set; }

        public Category Category { get; private set; } = null!;
        public Brand Brand { get; private set; } = null!;
    }
}
