namespace ConvenienceStore.Domain.Enums
{
    public enum InvoiceStatus
    {
        Pending,
        AwaitingPayment,
        Paid,
        Processing,
        Shipping,
        Completed,
        Cancelled,
        Refunded
    }
}
