using Torc.Royal.Library.Data;
using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Application.Books
{
    public class ListOwnedBooksByUserUseCase : UseCase<IEnumerable<Book>>, IListOwnedBooksByUserUseCase
    {
        private readonly IBookRepository bookRepository;

        public ListOwnedBooksByUserUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<ApiResult<IEnumerable<Book>>> Execute(int userId)
        {
            var books = await bookRepository.ListOwnedBooksByUserId(userId);
            if (books is not null && books.Any())
                return Success(books);

            return NotFound();
        }
    }
}