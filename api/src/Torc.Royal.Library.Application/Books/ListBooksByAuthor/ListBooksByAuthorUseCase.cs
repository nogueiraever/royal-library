using Torc.Royal.Library.Data;
using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Application.Books
{
    public class ListBooksByAuthorUseCase : UseCase<IEnumerable<Book>>, IListBooksByAuthorUseCase
    {
        private readonly IBookRepository bookRepository;

        public ListBooksByAuthorUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }
        public async Task<ApiResult<IEnumerable<Book>>> Execute(string authorNameOrLastName)
        {
            var books = await bookRepository.ListBooksByAuthor(authorNameOrLastName);
            if (books is not null && books.Any())
                return Success(books);

            return NotFound();
        }
    }
}