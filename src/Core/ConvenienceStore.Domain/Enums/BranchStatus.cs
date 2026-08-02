using System.Text.Json.Serialization;

namespace ConvenienceStore.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BranchStatus
    {
        Active,
        Inactive,
        Closed,
        UnderMaintenance
    }
}
