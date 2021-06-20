import { ActionCreators } from "../redux/booksReducer";

export const GetBooks = async (dispatch) => {
    try {
        // api call
        const response = [
            { title: 'first book',author:'me',publisher: 'iamald', id: 0 },
            { title: 'second book',author:'me',publisher: 'iamald', id: 1 },
            { title: 'third book',author:'me',publisher: 'iamald', id: 2 },
        ];

        dispatch(ActionCreators.setBooks(response));

    } catch {
        console.log('Error in services/books.js/GetBooks');
    }
}

export const DeleteBook = async (dispatch, book) => {
    try {
        dispatch(ActionCreators.deleteBook(book));
    } catch {
        console.log('Error in services/books.js/DeleteBook');
    }
}

export const EditBook = async (dispatch, book) => {
    try {
        const response = { value: book, id: 9 };
        dispatch(ActionCreators.editBook(response));
    } catch {
        console.log('Error in services/books.js/EditBook');
    }
}

export const NewBook = async (dispatch, book) => {
    try {
        const response = { value: book, id: 9 };
        dispatch(ActionCreators.newBook(response));
    } catch {
        console.log('Error in services/books.js/NewBook');
    }
}