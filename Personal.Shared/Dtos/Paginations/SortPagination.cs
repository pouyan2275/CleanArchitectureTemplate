namespace Personal.Shared.Dtos.Paginations;

public class SortPagination
{
    public required string Key { get; set; }
    public required bool Desc { get; set; } = true;

}
