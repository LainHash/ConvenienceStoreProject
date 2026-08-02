using System.Text.Json.Serialization;

namespace ConvenienceStore.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
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
