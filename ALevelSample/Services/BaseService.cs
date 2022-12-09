using System;
using System.Threading.Tasks;
using ALevelSample.Helpers;
using ALevelSample.Model;

namespace ALevelSample.Services;

public abstract class BaseService
{
    protected async Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> action)
        where TResult : Validation, new()
    {
        try
        {
           return await action();
        }
        catch (BusinessException e)
        {
            return new TResult
            {
                Error = e.Message,
                ErrorCode = e.ErrorCode
            };
        }
    }
}