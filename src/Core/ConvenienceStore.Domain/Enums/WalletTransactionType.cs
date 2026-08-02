using System.Text.Json.Serialization;

namespace ConvenienceStore.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WalletTransactionType
    {
        Deposit,
        Withdraw,
        Purchase,
        Refund,
        Adjustment,
        Expiration
    }
}
