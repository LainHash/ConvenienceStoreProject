using System.Text.Json.Serialization;

namespace ConvenienceStore.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WalletTransactionStatus
    {
        Pending,
        Processing,
        Succeeded,
        Failed,
        Cancelled
    }
}
