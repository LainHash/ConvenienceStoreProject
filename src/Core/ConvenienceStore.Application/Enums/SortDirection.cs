using System.Text.Json.Serialization;

namespace ConvenienceStore.Application.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortDirection
    {
        Asc,
        Desc
    }
}
