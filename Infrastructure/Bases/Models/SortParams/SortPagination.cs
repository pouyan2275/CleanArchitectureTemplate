namespace Infrastructure.Bases.Models.SortParams;

public class SortParam
{
    public required string Key { get; set; }
    public required bool Desc { get; set; } = true;

}
