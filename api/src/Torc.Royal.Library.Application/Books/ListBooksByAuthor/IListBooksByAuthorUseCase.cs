using Torc.Royal.Library.CrossCutting;

namespace Torc.Royal.Library.Application.Books
{
    public interface IListBooksByAuthorUseCase
    {
        Task<ApiResult<BooksListDTO>> Execute(string authorNameOrLastName, int page, int items);
    }
}