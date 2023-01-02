using Torc.Royal.Library.Data;
using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Application.Books
{
    public class ListLovedBooksByUserUseCase : UseCase<IEnumerable<Book>>, IListLovedBooksByUserUseCase
    {
        private readonly IBookRepository bookRepository;

        public ListLovedBooksByUserUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<ApiResult<IEnumerable<Book>>> Execute(int userId)
        {
            var books = await bookRepository.ListLovedBooksByUserId(userId);
            if (books is not null && books.Any())
                return Success(books);

            return NotFound();
        }
    }
}