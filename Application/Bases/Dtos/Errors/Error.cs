namespace Application.Bases.Dtos.Errors;

public class Error
{
    public int Code { get; set; }
    public string Description { get; set; } = string.Empty;
#if DEBUG
    public string Details { get; set; } = string.Empty ;
#endif

}
