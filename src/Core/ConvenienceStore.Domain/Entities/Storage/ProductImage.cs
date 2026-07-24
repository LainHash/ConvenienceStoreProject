using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Entities.Storage
{
    public class ProductImage : AuditableEntity
    {
        public int DisplayOrder { get; private set; }
        public bool IsPrimary { get; private set; }

        public int ProductId { get; private set; }
        public int ImageId { get; private set; }

        public Product Product { get; private set; } = null!;
        public Image Image { get; private set; } = null!;

        public static ProductImage Create(
            int productId,
            int imageId,
            bool isPrimary,
            int displayOrder)
        {
            return new ProductImage
            {
                ProductId = productId,
                ImageId = imageId,
                IsPrimary = isPrimary,
                DisplayOrder = displayOrder
            };
        }

        public void RemovePrimary()
        {
            IsPrimary = false;
        }
    }
}
