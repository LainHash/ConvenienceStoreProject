using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Guest;
using ConvenienceStore.Domain.Enums;

namespace ConvenienceStore.Domain.Entities.Financial
{
    public class Invoice : SoftDeletableEntity
    {
        public string InvoiceNumber { get; private set; } = string.Empty;

        public int? CustomerId { get; private set; }

        public decimal Subtotal { get; private set; }

        public decimal Discount { get; private set; }

        public decimal ShippingFee { get; private set; }

        public decimal Tax { get; private set; }

        public decimal TotalAmount { get; private set; }

        public InvoiceStatus Status { get; private set; }

        public string? Note { get; private set; }

        public Customer? Customer { get; private set; } = null!;

        public ICollection<InvoiceDetail> InvoiceDetails { get; private set; } = [];

        public ICollection<Payment> Payments { get; private set; } = [];
    }
}
