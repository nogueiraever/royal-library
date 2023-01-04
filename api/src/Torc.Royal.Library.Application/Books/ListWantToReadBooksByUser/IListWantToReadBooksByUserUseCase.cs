using Torc.Royal.Library.CrossCutting;

namespace Torc.Royal.Library.Application.Books
{
    public interface IListWantToReadBooksByUserUseCase
    {
        Task<ApiResult<BooksListDTO>> Execute(int userId, int page, int items);
    }
}