using System.Text.Json.Serialization;

namespace Infrastructure.Bases.Models.FilterParams;

public class FilterParam
{
    public required string Key { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required FilterOperator Operator { get; set; }
    public required string Value { get; set; }
}
