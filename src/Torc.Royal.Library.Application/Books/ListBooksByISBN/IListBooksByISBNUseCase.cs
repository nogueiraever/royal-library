using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Application.Books
{
    public interface IListBooksByISBNUseCase
    {
        Task<ApiResult<IEnumerable<Book>>> Execute(string isbnCode);
    }
}