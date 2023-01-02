using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Application.Books
{
    public interface IListWantToReadBooksByUserUseCase
    {
        Task<ApiResult<IEnumerable<Book>>> Execute(int userId);
    }
}