using Application.Bases.Dtos.Errors;

namespace Application.Bases.Dtos.BaseResult;

public class BaseResult<TResult> : BaseResult
{
    public TResult? Data { get; set; }
}

public class BaseResult
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public Error? Error { get; set; }
}
