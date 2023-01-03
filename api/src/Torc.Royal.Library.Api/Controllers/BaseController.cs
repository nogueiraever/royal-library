using Microsoft.AspNetCore.Mvc;
using Torc.Royal.Library.Application;

namespace Torc.Royal.Library.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        public IActionResult ApiResult<T>(ApiResult<T> result)
        {
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
