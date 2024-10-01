using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Infrastructure.Bases.Models.FilterParams;

public enum FilterOperator
{
    [Description("%")]
    Contains = 0,
    [Description("==")]
    Equal = 1,
    [Description("!=")]
    NotEqual = 2,
    [Description("<=")]
    LessThanOrEqual = 3,
    [Description("<")]
    LessThan = 4,
    [Description(">=")]
    GreaterThanOrEqual = 5,
    [Description(">")]
    GreaterThan = 6,
    [Description("IS NULL")]
    IsNull = 7,
    [Description("IS NOT NULL")]
    NotNull = 8
}
