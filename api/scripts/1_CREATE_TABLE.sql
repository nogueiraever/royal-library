CREATE TABLE dbo.user_books (
	book_id int NOT NULL,
	user_id int NOT NULL,
	own bit NOT NULL,
	love bit NOT NULL,
	want_to_read bit NOT NULL,
	CONSTRAINT user_books_FK FOREIGN KEY (book_id) REFERENCES torc.dbo.books(book_id)
);