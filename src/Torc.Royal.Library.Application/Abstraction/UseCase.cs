using System.Net;

namespace Torc.Royal.Library.Application
{
    public abstract class UseCase<TResult>
    {
        protected ApiResult<TResult> Success(TResult data)
        {
            return new ApiResult<TResult>(data);
        }

        protected ApiResult<TResult> NotFound()
        {
            return new ApiResult<TResult>(HttpStatusCode.NotFound);
        }
    }
}
