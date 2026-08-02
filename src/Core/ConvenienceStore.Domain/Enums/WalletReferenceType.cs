using System.Text.Json.Serialization;

namespace ConvenienceStore.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WalletReferenceType
    {
        Invoice,
        Payment,
        Refund,
        AdminAdjustment
    }
}
