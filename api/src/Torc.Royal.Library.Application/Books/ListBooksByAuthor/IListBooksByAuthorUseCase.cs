using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Application.Books
{
    public interface IListBooksByAuthorUseCase
    {
        Task<ApiResult<IEnumerable<Book>>> Execute(string authorNameOrLastName);
    }
}