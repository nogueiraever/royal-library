using Torc.Royal.Library.CrossCutting;
using Torc.Royal.Library.Data;

namespace Torc.Royal.Library.Application.Books
{
    public class ListBooksByAuthorUseCase : UseCase<BooksListDTO>, IListBooksByAuthorUseCase
    {
        private readonly IBookRepository bookRepository;

        public ListBooksByAuthorUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }
        public async Task<ApiResult<BooksListDTO>> Execute(string authorNameOrLastName, int page, int items)
        {
            var booksDto = await bookRepository.ListBooksByAuthor(authorNameOrLastName, page, items);
            if (booksDto is not null)
            {
                return Success(booksDto);
            }

            return NotFound();
        }
    }
}