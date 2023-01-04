using Microsoft.AspNetCore.Mvc;
using Torc.Royal.Library.Application.Books;

namespace Torc.Royal.Library.Api.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : BaseController
    {
        [HttpGet("authors/{authorNameOrLastName}")]
        public async Task<IActionResult> ListBooksByAuthor(string authorNameOrLastName, int page, int items, [FromServices] IListBooksByAuthorUseCase useCase)
        {
            return ApiResult(await useCase.Execute(authorNameOrLastName, page, items));
        }

        [HttpGet("isbn/{isbnCode}")]
        public async Task<IActionResult> ListBooksByISBN(string isbnCode, int page, int items, [FromServices] IListBooksByISBNUseCase useCase)
        {
            return ApiResult(await useCase.Execute(isbnCode, page, items));
        }

        [HttpGet("users/{userId}/owned")]
        public async Task<IActionResult> ListOwnedBooksByUser(int userId, int page, int items, [FromServices] IListOwnedBooksByUserUseCase useCase)
        {
            return ApiResult(await useCase.Execute(userId, page, items));
        }

        [HttpGet("users/{userId}/loved")]
        public async Task<IActionResult> ListLovedBooksByUser(int userId, int page, int items, [FromServices] IListLovedBooksByUserUseCase useCase)
        {
            return ApiResult(await useCase.Execute(userId, page, items));
        }


        [HttpGet("users/{userId}/want-read")]
        public async Task<IActionResult> ListWantToReadBooksByUser(int userId, int page, int items, [FromServices] IListWantToReadBooksByUserUseCase useCase)
        {
            return ApiResult(await useCase.Execute(userId, page, items));
        }
    }
}
