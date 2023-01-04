using Torc.Royal.Library.CrossCutting;
using Torc.Royal.Library.Data;

namespace Torc.Royal.Library.Application.Books
{
    public class ListBooksByISBNUseCase : UseCase<BooksListDTO>, IListBooksByISBNUseCase
    {
        private readonly IBookRepository bookRepository;

        public ListBooksByISBNUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<ApiResult<BooksListDTO>> Execute(string isbnCode, int page, int items)
        {
            var books = await bookRepository.ListBooksByISBN(isbnCode, page, items);
            if (books is not null)
                return Success(books);

            return NotFound();
        }
    }
}