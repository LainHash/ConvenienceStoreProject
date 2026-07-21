using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Entities.Inventory
{
    public class ProductStock : SoftDeletableEntity
    {
        public decimal UnitPrice { get; private set; }
        public string Unit { get; private set; } = string.Empty;
        public int QuantityOnHand {  get; private set; }

        public int ProductId { get; private set; }

        public Product Product { get; private set; } = null!;
    }
}
