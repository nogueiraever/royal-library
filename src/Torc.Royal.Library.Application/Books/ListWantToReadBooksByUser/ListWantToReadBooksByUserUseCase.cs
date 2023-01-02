using Torc.Royal.Library.Data;
using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Application.Books
{
    public class ListWantToReadBooksByUserUseCase : UseCase<IEnumerable<Book>>, IListWantToReadBooksByUserUseCase
    {
        private readonly IBookRepository bookRepository;

        public ListWantToReadBooksByUserUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<ApiResult<IEnumerable<Book>>> Execute(int userId)
        {
            var books = await bookRepository.ListWantToReadBooksByUserId(userId);
            if (books is not null && books.Any())
                return Success(books);

            return NotFound();
        }
    }
}