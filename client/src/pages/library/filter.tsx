import { Box, Button, Container, FormControl, IconButton, InputLabel, MenuItem, Select, TextField } from '@mui/material';
import ClearIcon from "@mui/icons-material/Clear";
import React, { useContext, useState } from 'react';
import { BooksContext } from '../../contexts/books-context';
import { BookFilterType } from '../../models/book/book-filter-type';

const LibraryFilter: React.FC = () => {
    const [disabledFilterValue, setDisabledFilterValue] = useState<boolean>(false);

    const { page, setPage, rowsPerPage, filterBooks, filterType, setFilterType, filterValue, setFilterValue } = useContext(BooksContext);

    const filterLabel = () => disabledFilterValue ? "Not valid for this filter type" : "Type the filter value"

    const clearFilter = () => {
        setFilterType(BookFilterType.NoFilter)
        setFilterValue(undefined)
    }

    const onChangeFilterType = (e: any) => {
        const selectedFilterType = e.target.value as BookFilterType;

        setFilterType(selectedFilterType)
        setFilterValue(undefined)

        if (selectedFilterType === BookFilterType.Loved ||
            selectedFilterType === BookFilterType.Owned ||
            selectedFilterType === BookFilterType.WantToRead) {
            setDisabledFilterValue(true)
        }
        else
            setDisabledFilterValue(false)
    }


    const filterData = () => {
        setPage(0)
        filterBooks(filterType, filterValue, page, rowsPerPage)
    }

    return (
        <Container maxWidth="md">
            <FormControl fullWidth>
                <InputLabel id="demo-simple-select-label">Filter by</InputLabel>
                <Select
                    labelId="demo-simple-select-label"
                    value={filterType ?? " "}
                    label="Filter types"
                    onChange={onChangeFilterType}
                    endAdornment={<IconButton sx={{ display: filterType ? "" : "none" }} onClick={clearFilter}><ClearIcon /></IconButton>}
                >
                    <MenuItem value={BookFilterType.NoFilter}>Please select an option</MenuItem>
                    <MenuItem value={BookFilterType.Author}>Author</MenuItem>
                    <MenuItem value={BookFilterType.ISBN}>ISBN</MenuItem>
                    <MenuItem value={BookFilterType.Owned}>OWN</MenuItem>
                    <MenuItem value={BookFilterType.Loved}>Love</MenuItem>
                    <MenuItem value={BookFilterType.WantToRead}>Want to read</MenuItem>
                </Select>
            </FormControl>
            <FormControl fullWidth>
                <TextField id="standard-basic" label={filterLabel()} variant="standard"
                    value={filterValue ?? ""}
                    onChange={(e) => setFilterValue(e.target.value)}
                    disabled={disabledFilterValue}
                />
            </FormControl>
            <Box sx={{ my: 4 }}>
                <Button variant="contained" onClick={filterData}>Search</Button>
            </Box>
        </Container>
    );
}

export default LibraryFilter;