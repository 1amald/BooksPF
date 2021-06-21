import { ActionCreators } from "../redux/booksReducer";
import { api } from "../http";

export const GetBooks = async (dispatch) => {
    try {
        const { data } = await api.get('book/list');
        dispatch(ActionCreators.setBooks(data));
    } catch (err) {
        console.log(err.message);
    }
}

export const DeleteBook = async (dispatch, book) => {
    try {
        const { data } = await api.delete('book/delete',{params: {id: book.id}});
        dispatch(ActionCreators.deleteBook(book));
    } catch (err){
        console.log(err.message);
    }
}

export const EditBook = async (dispatch, book) => {
    try {
        const { data } = await api.put('book/edit',book);
        dispatch(ActionCreators.editBook(data));
    } catch {
        console.log('Error');
    }
}

export const NewBook = async (dispatch, book) => {
    try {
        const { data } = await api.post('book/create',book);
        dispatch(ActionCreators.newBook(data));
    } catch {
        console.log('Error');
    }
}