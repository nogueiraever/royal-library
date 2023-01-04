using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Torc.Royal.Library.CrossCutting;
using Torc.Royal.Library.Domain;

namespace Torc.Royal.Library.Data
{
    public class BookRepository : IBookRepository
    {
        public BookRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("RoyalLibrary");
        }

        const string QUERY_BOOKS_COLUMNS = @"SELECT
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
												dbo.books b";

        const string QUERY_PAGINATION = @$"OFFSET @page ROWS
										   FETCH NEXT @items ROWS ONLY;";

        const string QUERY_TOTAL_BOOKS = $@"SELECT
											count(b.book_id)
										FROM
											dbo.books b";
        private readonly string connectionString;

        public async Task<BooksListDTO> ListBooksByAuthor(string authorNameOrLastName, int page, int items)
        {
            var filter = @$"WHERE
							    first_name LIKE @authorNameOrLastName
							    or last_name LIKE @authorNameOrLastName";

            var orderBy = "ORDER BY book_id";
            string query = FormatQuery(filter, orderBy);

            using var connection = new SqlConnection(connectionString);

            using var multi = await connection.QueryMultipleAsync(query, new { authorNameOrLastName = $"%{authorNameOrLastName}%", items, page = CalculatePagination(page, items) });
            var total = multi.Read<int>().FirstOrDefault();
            var books = multi.Read<Book>();

            return new BooksListDTO(total, books);
        }

        public async Task<BooksListDTO> ListBooksByISBN(string isbnCode, int page, int items)
        {
            var filter = @$"WHERE
								isbn LIKE @isbnCode";

            var orderBy = "ORDER BY book_id";
            string query = FormatQuery(filter, orderBy);

            using var connection = new SqlConnection(connectionString);

            using var multi = await connection.QueryMultipleAsync(query, new { isbnCode = $"%{isbnCode}%", items, page = CalculatePagination(page, items) });
            var total = multi.Read<int>().FirstOrDefault();
            var books = multi.Read<Book>();

            return new BooksListDTO(total, books);
        }



        public async Task<BooksListDTO> ListOwnedBooksByUserId(int userId, int page, int items)
        {
            var filter = @$"INNER JOIN user_books ub on
							ub.book_id = b.book_id
						WHERE
							ub.user_id = @userId and
							ub.own = 1";

            var orderBy = "ORDER BY book_id";
            string query = FormatQuery(filter, orderBy);

            using var connection = new SqlConnection(connectionString);

            using var multi = await connection.QueryMultipleAsync(query, new { userId, items, page = CalculatePagination(page, items) });
            var total = multi.Read<int>().FirstOrDefault();
            var books = multi.Read<Book>();

            return new BooksListDTO(total, books);
        }

        public async Task<BooksListDTO> ListLovedBooksByUserId(int userId, int page, int items)
        {
            var filter = @$"INNER JOIN user_books ub on
							ub.book_id = b.book_id
						WHERE
							ub.user_id = @userId and
							ub.love = 1";

            var orderBy = "ORDER BY book_id";
            string query = FormatQuery(filter, orderBy);

            using var connection = new SqlConnection(connectionString);

            using var multi = await connection.QueryMultipleAsync(query, new { userId, items, page = CalculatePagination(page, items) });
            var total = multi.Read<int>().FirstOrDefault();
            var books = multi.Read<Book>();

            return new BooksListDTO(total, books);
        }

        public async Task<BooksListDTO> ListWantToReadBooksByUserId(int userId, int page, int items)
        {
            var filter = @$"INNER JOIN user_books ub on
							ub.book_id = b.book_id
						WHERE
							ub.user_id = @userId and
							ub.want_to_read = 1";

            var orderBy = "ORDER BY book_id";
            string query = FormatQuery(filter, orderBy);

            using var connection = new SqlConnection(connectionString);

            using var multi = await connection.QueryMultipleAsync(query, new { userId, items, page = CalculatePagination(page, items) });
            var total = multi.Read<int>().FirstOrDefault();
            var books = multi.Read<Book>();

            return new BooksListDTO(total, books);
        }

        private static int CalculatePagination(int page, int items)
        {
            return page * items;
        }

        private static string FormatQuery(string filter, string orderBY)
        {
            return $@"{QUERY_TOTAL_BOOKS}
							{filter}
					  {QUERY_BOOKS_COLUMNS}
							{filter}
                            {orderBY}
					  {QUERY_PAGINATION}";
        }
    }
}
