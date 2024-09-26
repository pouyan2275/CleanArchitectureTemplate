using System.Text.Json.Serialization;

namespace Application.Bases.Dtos.Paginations;

public class FilterPagination
{
    public required string Key { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required FilterOperator Operator { get; set; }
    public required string Value { get; set; }
}
