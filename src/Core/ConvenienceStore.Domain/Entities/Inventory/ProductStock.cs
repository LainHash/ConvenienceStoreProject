using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Catalog;
using ConvenienceStore.Domain.Entities.Territory;

namespace ConvenienceStore.Domain.Entities.Inventory
{
    public class ProductStock : SoftDeletableEntity
    {
        public string Unit { get; private set; } = string.Empty;
        public int QuantityOnHand {  get; private set; }

        public int ProductId { get; private set; }
        public int BranchId { get; private set; }

        public Product Product { get; private set; } = null!;
        public Branch Branch { get; private set; } = null!;
    }
}
