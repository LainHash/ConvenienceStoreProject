using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Inventory;

namespace ConvenienceStore.Domain.Entities.Catalog
{
    public partial class Product : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public int CategoryId { get; private set; }
        public int BrandId { get; private set; }

        public Category Category { get; private set; } = null!;
        public Brand Brand { get; private set; } = null!;
        public ProductStock ProductStock { get; private set; } = null!;
    }

    public partial class Product
    {
        public Product() { }

        public Product(int categoryId, int brandId)
        {
            CategoryId = categoryId;
            BrandId = brandId;
        }

        public static Product Create(int categoryId, int brandId)
        {
            return new Product(categoryId, brandId);
        }
    }
}
