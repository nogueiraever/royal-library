using Microsoft.AspNetCore.Mvc;
using Torc.Royal.Library.Application.Books;

namespace Torc.Royal.Library.Api.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : BaseController
    {
        [HttpGet("authors/{authorNameOrLastName}")]
        public async Task<IActionResult> ListBooksByAuthor(string authorNameOrLastName, [FromServices] IListBooksByAuthorUseCase useCase)
        {
            return ApiResult(await useCase.Execute(authorNameOrLastName));
        }

        [HttpGet("isbn/{isbnCode}")]
        public async Task<IActionResult> ListBooksByISBN(string isbnCode, [FromServices] IListBooksByISBNUseCase useCase)
        {
            return ApiResult(await useCase.Execute(isbnCode));
        }
        
        [HttpGet("users/{userId}/owned")]
        public async Task<IActionResult> ListOwnedBooksByUser(int userId, [FromServices] IListOwnedBooksByUserUseCase useCase)
        {
            return ApiResult(await useCase.Execute(userId));
        }

        [HttpGet("users/{userId}/loved")]
        public async Task<IActionResult> ListLovedBooksByUser(int userId, [FromServices] IListLovedBooksByUserUseCase useCase)
        {
            return ApiResult(await useCase.Execute(userId));
        }


        [HttpGet("users/{userId}/want-read")]
        public async Task<IActionResult> ListWantToReadBooksByUser(int userId, [FromServices] IListWantToReadBooksByUserUseCase useCase)
        {
            return ApiResult(await useCase.Execute(userId));
        }
    }
}
