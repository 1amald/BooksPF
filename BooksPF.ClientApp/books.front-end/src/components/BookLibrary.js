import React, { useEffect } from 'react';
import { NewBookModal } from "./BookModal";
import { useSelector, useDispatch } from 'react-redux';
import { GetBooks } from '../services/books';
import { MyBookRow,BookRow } from "./BookRow";

export function MyBooks() {
    const books = useSelector(state => state.booksReducer.books);
    const dispatch = useDispatch();

    useEffect(() => {
        GetBooks(dispatch);
    }, []);

    return (
        <div>
            <NewBookModal />
            <div>{books.map(n=>
                <MyBookRow book ={n} dispatch={dispatch}/>
                )}</div>
        </div>
    )
}

export function AllBooks(){
    const books = useSelector(state => state.booksReducer.books);
    const dispatch = useDispatch();

    useEffect(() => {
        GetBooks(dispatch);
    }, []);

    return (
        <div>
            <div>{books.map(n=>
                <BookRow book ={n} dispatch={dispatch}/>
                )}</div>
        </div>
    )
}