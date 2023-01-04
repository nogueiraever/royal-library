import { createContext } from "react"
import { BookFilterType } from "../models/book/book-filter-type"

interface BooksContextType {
    booksList: any[],
    setBooksList: any,
    totalBooks: number,
    setTotalBooks: any,
    page: number,
    setPage: any,
    rowsPerPage: number,
    setRowsPerPage: any,
    filterBooks: (filterType?: BookFilterType | undefined, filterValue?: string | undefined, page?: number, items?: number) => void,
    filterValue: string,
    setFilterValue: any,
    filterType: BookFilterType,
    setFilterType: any
}

export const BooksContext = createContext({} as BooksContextType)
