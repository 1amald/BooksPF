import React, { useEffect } from 'react';
import { Button } from 'react-bootstrap';
import { useSelector, useDispatch } from 'react-redux';
import { DeleteBook, GetBooks } from '../services/books';
import { EditBookModal } from './BookModal';

export function BooksTable(){
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
                    <td>{n.publisher}</td>
                    <td><EditBookModal book = {n}/></td>
                    <td>
                        <Button className = 'btn btn-danger' onClick ={() => DeleteBook(dispatch,n)} value ="Delete">Delete</Button>
                    </td>
                </tr>)
            }
        </tbody>
    </table>
}