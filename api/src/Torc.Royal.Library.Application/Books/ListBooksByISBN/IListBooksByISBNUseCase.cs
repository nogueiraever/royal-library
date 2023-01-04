using Torc.Royal.Library.CrossCutting;

namespace Torc.Royal.Library.Application.Books
{
    public interface IListBooksByISBNUseCase
    {
        Task<ApiResult<BooksListDTO>> Execute(string isbnCode, int page, int items);
    }
}