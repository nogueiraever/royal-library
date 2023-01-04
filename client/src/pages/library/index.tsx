import { Container, Typography } from '@mui/material';
import React, { useState } from 'react';
import { BooksContext } from '../../contexts/books-context';
import { BookFilterType } from '../../models/book/book-filter-type';
import booksService from '../../services/books-service';
import BooksList from './books-list';
import LibraryFilter from './filter'

const Library: React.FC = () => {
    const [booksList, setBooksList] = useState([])
    const [page, setPage] = useState(0);
    const [totalBooks, setTotalBooks] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(5);
    const [filterType, setFilterType] = useState(BookFilterType.NoFilter);
    const [filterValue, setFilterValue] = useState('');


    const filterBooks = async (filterType?: BookFilterType | undefined, filterValue?: string | undefined, page: number = 0, items: number = 5) => {
        try {
            const response = await booksService?.filterBooks(2, filterType, filterValue, page, items)
            if (response) {
                setBooksList(response.data.books)
                setTotalBooks(response.data.totalBooks)
            }
        } catch (error) {
            setBooksList([])
        }
    }


    const providerDefaultValues = {
        booksList,
        setBooksList,
        page,
        setPage,
        rowsPerPage,
        setRowsPerPage,
        totalBooks,
        setTotalBooks,
        filterBooks,
        filterValue,
        setFilterValue,
        filterType,
        setFilterType
    }

    return <>
        <Container maxWidth="xl">
            <Typography>
                Using a mocked user id: 2
            </Typography>
            <BooksContext.Provider value={providerDefaultValues}>
                <LibraryFilter />
                <BooksList />
            </BooksContext.Provider>
        </Container>
    </>;
}

export default Library;