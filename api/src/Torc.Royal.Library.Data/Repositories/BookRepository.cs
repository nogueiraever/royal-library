using Dapper;
using Microsoft.Data.SqlClient;
using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Data
{
    public class BookRepository : IBookRepository
    {
        public async Task<IEnumerable<Book>> ListBooksByAuthor(string authorNameOrLastName)
        {
            var query = @"SELECT
							book_id,
							title,
							first_name as FirstName,
							last_name as LastName,
							total_copies as TotalCopies,
							copies_in_use as CopiesInUse,
							[type],
							isbn,
							category
						FROM
							dbo.books
						where
							first_name LIKE @authorNameOrLastName;";

            using var connection = new SqlConnection("Server=localhost;Database=torc;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa;Password=!sql2010;Encrypt=false;");
            return await connection.QueryAsync<Book>(query, new { authorNameOrLastName = $"%{authorNameOrLastName}%" });
        }

        public async Task<IEnumerable<Book>> ListBooksByISBN(string isbnCode)
        {
            var query = @"SELECT
							book_id,
							title,
							first_name as FirstName,
							last_name as LastName,
							total_copies as TotalCopies,
							copies_in_use as CopiesInUse,
							[type],
							isbn,
							category
						FROM
							dbo.books
						where
							isbn LIKE @isbnCode;";

            using var connection = new SqlConnection("Server=localhost;Database=torc;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa;Password=!sql2010;Encrypt=false;");
            return await connection.QueryAsync<Book>(query, new { isbnCode = $"%{isbnCode}%" });
        }

        public async Task<IEnumerable<Book>> ListOwnedBooksByUserId(int userId)
        {
            var query = @"SELECT
							b.book_id,
							title,
							first_name as FirstName,
							last_name as LastName,
							total_copies as TotalCopies,
							copies_in_use as CopiesInUse,
							[type],
							isbn,
							category
						FROM
							dbo.books b
						inner join user_books ub on
							ub.book_id = b.book_id
						where
							ub.user_id = @userId and
							ub.own = 1";

            using var connection = new SqlConnection("Server=localhost;Database=torc;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa;Password=!sql2010;Encrypt=false;");
            return await connection.QueryAsync<Book>(query, new { userId });
        }

        public async Task<IEnumerable<Book>> ListLovedBooksByUserId(int userId)
        {
            var query = @"SELECT
							b.book_id,
							title,
							first_name as FirstName,
							last_name as LastName,
							total_copies as TotalCopies,
							copies_in_use as CopiesInUse,
							[type],
							isbn,
							category
						FROM
							dbo.books b
						inner join user_books ub on
							ub.book_id = b.book_id
						where
							ub.user_id = @userId and
							ub.love = 1";

            using var connection = new SqlConnection("Server=localhost;Database=torc;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa;Password=!sql2010;Encrypt=false;");
            return await connection.QueryAsync<Book>(query, new { userId });
        }

        public async Task<IEnumerable<Book>> ListWantToReadBooksByUserId(int userId)
        {
            var query = @"SELECT
							b.book_id,
							title,
							first_name as FirstName,
							last_name as LastName,
							total_copies as TotalCopies,
							copies_in_use as CopiesInUse,
							[type],
							isbn,
							category
						FROM
							dbo.books b
						inner join user_books ub on
							ub.book_id = b.book_id
						where
							ub.user_id = @userId and
							ub.want_to_read = 1";

            using var connection = new SqlConnection("Server=localhost;Database=torc;Trusted_Connection=False;MultipleActiveResultSets=true;User Id=sa;Password=!sql2010;Encrypt=false;");
            return await connection.QueryAsync<Book>(query, new { userId });
        }
    }
}
