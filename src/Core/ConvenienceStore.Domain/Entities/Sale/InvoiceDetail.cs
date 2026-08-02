using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Catalog;

namespace ConvenienceStore.Domain.Entities.Sale
{
    public class InvoiceDetail : SoftDeletableEntity
    {
        public int InvoiceId { get; private set; }

        public int ProductId { get; private set; }

        public string ProductName { get; private set; } = string.Empty;

        public decimal UnitPrice { get; private set; }

        public int Quantity { get; private set; }

        public decimal Discount { get; private set; }

        public decimal LineTotal { get; private set; }

        public Product Product { get; private set; } = null!;
        public Invoice Invoice { get; private set; } = null!;
    }
}
