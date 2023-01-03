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

        public ApiResult(TApiResult data, HttpStatusCode httpStatusCode)
        {
            Data = data;
            StatusCode = httpStatusCode;
        }
        public ApiResult(IEnumerable<string> messages, HttpStatusCode statusCode)
        {
            Messages = messages;
            StatusCode = statusCode;
        }

        public ApiResult(string message, HttpStatusCode httpStatusCode)
        {
            Messages = new List<string> { message };
            StatusCode = httpStatusCode;
        }

        public TApiResult Data { get; }
        public IEnumerable<string> Messages { get; } = new List<string>();
        [JsonIgnore]
        public HttpStatusCode? StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
