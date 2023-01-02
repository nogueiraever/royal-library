using Torc.Royal.Library.Data;
using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Application.Books
{
    public class ListBooksByISBNUseCase : UseCase<IEnumerable<Book>>, IListBooksByISBNUseCase
    {
        private readonly IBookRepository bookRepository;

        public ListBooksByISBNUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<ApiResult<IEnumerable<Book>>> Execute(string isbnCode)
        {
            var books = await bookRepository.ListBooksByISBN(isbnCode);
            if (books is not null && books.Any())
                return Success(books);

            return NotFound();
        }
    }
}