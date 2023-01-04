using Torc.Royal.Library.CrossCutting;

namespace Torc.Royal.Library.Data
{
    public interface IBookRepository
    {
        Task<BooksListDTO> ListBooksByAuthor(string authorNameOrLastName, int page, int items);
        Task<BooksListDTO> ListBooksByISBN(string isbnCode, int page, int items);
        Task<BooksListDTO> ListOwnedBooksByUserId(int userId, int page, int items);
        Task<BooksListDTO> ListLovedBooksByUserId(int userId, int page, int items);
        Task<BooksListDTO> ListWantToReadBooksByUserId(int userId, int page, int items);
    }
}