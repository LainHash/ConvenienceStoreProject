using System.Text.Json.Serialization;

namespace ConvenienceStore.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StockStatus
    {
        InStock,
        LowStock,
        OutOfStock
    }
}
