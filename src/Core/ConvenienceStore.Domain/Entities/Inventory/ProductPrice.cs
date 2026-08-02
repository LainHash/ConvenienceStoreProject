using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Entities.Inventory
{
    public class ProductPrice : SoftDeletableEntity
    {
        public decimal UnitPrice { get; private set; }

        public int ProductId { get; private set; }

        public Product Product { get; private set; } = null!;
    }
}
