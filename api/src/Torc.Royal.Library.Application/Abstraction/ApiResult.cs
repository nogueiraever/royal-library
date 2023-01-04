using System.Net;
using System.Text.Json.Serialization;

namespace Torc.Royal.Library.Application
{
    public class ApiResult<TApiResult>
    {
        protected ApiResult()
        {
        }
        public ApiResult(TApiResult data)
        {
            Data = data;
        }

        public ApiResult(HttpStatusCode? httpStatusCode)
        {
            StatusCode = httpStatusCode;
        }
        
        public TApiResult Data { get; }
        [JsonIgnore]
        public HttpStatusCode? StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
