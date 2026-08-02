using ConvenienceStore.Domain.Abstraction;
using ConvenienceStore.Domain.Entities.Sale;
using ConvenienceStore.Domain.Enums;

namespace ConvenienceStore.Domain.Entities.Financial
{
    public class Payment : SoftDeletableEntity
    {
        public int InvoiceId { get; private set; }

        public decimal Amount { get; private set; }

        public PaymentMethod Method { get; private set; }

        public PaymentStatus Status { get; private set; }

        public string? TransactionId { get; private set; }

        public string? Provider { get; private set; }

        public DateTime? PaidAt { get; private set; }

        public string? FailureReason { get; private set; }

        public Invoice Invoice { get; private set; } = null!;
    }
}
