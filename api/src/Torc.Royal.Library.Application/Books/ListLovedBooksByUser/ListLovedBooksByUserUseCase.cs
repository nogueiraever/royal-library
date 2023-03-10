using Torc.Royal.Library.CrossCutting;
using Torc.Royal.Library.Data;

namespace Torc.Royal.Library.Application.Books
{
    public class ListLovedBooksByUserUseCase : UseCase<BooksListDTO>, IListLovedBooksByUserUseCase
    {
        private readonly IBookRepository bookRepository;

        public ListLovedBooksByUserUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<ApiResult<BooksListDTO>> Execute(int userId, int page, int items)
        {
            var books = await bookRepository.ListLovedBooksByUserId(userId, page, items);
            if (books is not null)
                return Success(books);

            return NotFound();
        }
    }
}