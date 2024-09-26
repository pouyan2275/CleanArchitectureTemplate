using Application.Bases.Dtos.BaseResult;

namespace Application.Bases.ResponseHelpers;


public static class BaseResultHelper<TResult>
{
    public static BaseResult<TResult> CreateSuccessResponse(TResult data,string message)
    {
        return new BaseResult<TResult>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }
}

