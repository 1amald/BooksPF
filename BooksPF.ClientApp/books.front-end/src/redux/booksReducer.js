const initialState = {
    books: [],
}

export const ActionTypes = {
    SET_BOOKS: 'SET_BOOKS',
    DELETE_BOOK: 'DELETE_BOOK',
    EDIT_BOOK: 'EDIT_BOOK',
    NEW_BOOK: 'NEW_BOOK'
}

export const ActionCreators = {
    setBooks: payload => ({ type: ActionTypes.SET_BOOKS, payload }),
    deleteBook: payload => ({ type: ActionTypes.DELETE_BOOK, payload }),
    editBook: payload => ({ type: ActionTypes.EDIT_BOOK, payload }),
    newBook: payload => ({ type: ActionTypes.NEW_BOOK, payload }),
}

export default function BooksReducer(state = initialState, action) {
    switch (action.type) {

        case ActionTypes.SET_BOOKS:
            return { ...state, books: [...action.payload] };

        case ActionTypes.DELETE_BOOK:
            return {
                ...state, books: [...state.books.filter(book =>
                    book.id !== action.payload.id)]
            };

        case ActionTypes.EDIT_BOOK:
            let books = state.books.map(book => {
                if (book.id === action.payload.id) {
                    book = action.payload
                }
                return book;
            })
            return { ...state, books: [...books] };

        case ActionTypes.NEW_BOOK:
            console.log('doshel do reducera');
            return {...state, books: [...state.books, action.payload]}

        default:
            return state;
    }
}