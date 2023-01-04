import api from '../infra/api'
import { BookFilterType } from '../models/book/book-filter-type'

class BooksService {
    listOwnedBooks(userId: number, page: number, items: number) {
        return api.get(`api/v1/books/users/${userId}/owned?page=${page}&items=${items}`)
    }

    listLovedBooks(userId: number, page: number, items: number) {
        return api.get(`api/v1/books/users/${userId}/loved?page=${page}&items=${items}`)
    }

    listWantToReadBooks(userId: number, page: number, items: number) {
        return api.get(`api/v1/books/users/${userId}/want-read?page=${page}&items=${items}`)
    }

    listBooksByAuthor(userId: number, filterValue: string | undefined, page: number, items: number) {
        return api.get(`api/v1/books/authors/${filterValue}?page=${page}&items=${items}`)
    }

    listBooksByISBN(userId: number, filterValue: string | undefined, page: number, items: number) {
        return api.get(`api/v1/books/isbn/${filterValue}?page=${page}&items=${items}`)
    }

    filterBooks(userId: number, filterType?: BookFilterType | undefined, filterValue?: string | undefined, page: number = 0, items: number = 5) {
        switch (filterType) {
            case BookFilterType.Author:
                return this.listBooksByAuthor(userId, filterValue, page, items)
            case BookFilterType.ISBN:
                return this.listBooksByISBN(userId, filterValue, page, items)
            case BookFilterType.Loved:
                return this.listLovedBooks(userId, page, items)
            case BookFilterType.Owned:
                return this.listOwnedBooks(userId, page, items)
            case BookFilterType.WantToRead:
                return this.listWantToReadBooks(userId, page, items)
        }
    }
}

export default new BooksService();