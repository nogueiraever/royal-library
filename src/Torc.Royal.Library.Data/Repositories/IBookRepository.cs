using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Data
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListBooksByAuthor(string authorNameOrLastName);
        Task<IEnumerable<Book>> ListBooksByISBN(string isbnCode);
        Task<IEnumerable<Book>> ListOwnedBooksByUserId(int userId);
        Task<IEnumerable<Book>> ListLovedBooksByUserId(int userId);
        Task<IEnumerable<Book>> ListWantToReadBooksByUserId(int userId);
    }
}