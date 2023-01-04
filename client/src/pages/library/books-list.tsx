import { Typography, TableContainer, Paper, Table, TableHead, TableRow, TableCell, TableBody, Box, TableFooter, TablePagination } from '@mui/material';
import TablePaginationActions from '@mui/material/TablePagination/TablePaginationActions';
import React, { useContext } from 'react';
import { BooksContext } from '../../contexts/books-context';

const BooksList: React.FC = () => {

    const { booksList, page, setPage, rowsPerPage, setRowsPerPage, totalBooks, filterBooks, filterValue, filterType } = useContext(BooksContext);

    const handleChangePage = (
        event: React.MouseEvent<HTMLButtonElement> | null,
        newPage: number,
    ) => {
        setPage(newPage);
        filterBooks(filterType, filterValue, newPage, rowsPerPage)
    };

    const handleChangeRowsPerPage = (
        event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
    ) => {
        const items = parseInt(event.target.value, 10);
        setRowsPerPage(items);
        setPage(0);
        filterBooks(filterType, filterValue, 0, items)
    };


    return (<Box sx={{ my: 4 }}>
        <Typography variant="h4" component="h1" gutterBottom>
            Search Results
        </Typography>
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell>Book Title</TableCell>
                        <TableCell align="left">Authors</TableCell>
                        <TableCell align="left">Type</TableCell>
                        <TableCell align="center">ISBN</TableCell>
                        <TableCell align="center">Category</TableCell>
                        <TableCell align="center">Available Copies</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {booksList.map((row) => (
                        <TableRow
                            key={row.name}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                            <TableCell component="th" scope="row">
                                {row.title}
                            </TableCell>
                            <TableCell align="left">{row.authors}</TableCell>
                            <TableCell align="left">{row.type}</TableCell>
                            <TableCell align="center">{row.isbn}</TableCell>
                            <TableCell align="center">{row.category}</TableCell>
                            <TableCell align="center">{row.availableCopies}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
                <TableFooter>
                    <TableRow>
                        <TablePagination
                            rowsPerPageOptions={[2, 5, 10, 25, { label: 'All', value: -1 }]}
                            colSpan={3}
                            count={totalBooks}
                            rowsPerPage={rowsPerPage}
                            page={page}
                            SelectProps={{
                                inputProps: {
                                    'aria-label': 'rows per page',
                                },
                                native: true,
                            }}
                            onPageChange={handleChangePage}
                            onRowsPerPageChange={handleChangeRowsPerPage}
                            ActionsComponent={TablePaginationActions}
                        />
                    </TableRow>
                </TableFooter>
            </Table>
        </TableContainer>
    </Box>
    );
}

export default BooksList;