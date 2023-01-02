using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Application.Books
{
    public interface IListLovedBooksByUserUseCase
    {
        Task<ApiResult<IEnumerable<Book>>> Execute(int userId);
    }
}