using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Application.Books
{
    public interface IListOwnedBooksByUserUseCase
    {
        Task<ApiResult<IEnumerable<Book>>> Execute(int userId);
    }
}