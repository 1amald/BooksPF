import React, { useEffect } from 'react';
import { Button } from 'react-bootstrap';
import { useSelector, useDispatch } from 'react-redux';
import { DeleteBook, GetBooks } from '../services/books';
import { EditBookModal } from './BookModal';

export default function BooksTable(){
    const books = useSelector(state => state.booksReducer.books);
    const dispatch = useDispatch();
    useEffect(() => {
        GetBooks(dispatch);
    },[]);

    return <table className ='table table-white '>
        <tbody>
            {
                books.map(n=> 
                <tr>
                    <td>{n.author}</td>
                    <td>{n.title}</td>
                    <td>{n.holderName}</td>
                    <td><EditBookModal book = {n}/></td>
                    <td>
                        <Button className = 'btn btn-danger' onClick ={() => DeleteBook(dispatch,n)}>Delete</Button>
                    </td>
                </tr>)
            }
        </tbody>
    </table>
}