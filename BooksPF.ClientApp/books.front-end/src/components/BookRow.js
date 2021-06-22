import React, { useState } from 'react';
import { EditBookModal } from './BookModal';
import { EditBook, DeleteBook } from '../services/books';
import { Button } from 'react-bootstrap';
import image from '../image.jpg'

export const MyBookRow = ({ dispatch, book }) => {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return (
        <div className='div-book-row'>
            <div style ={{display:'flex'}}>
                <img src={image} width='150px' style ={{margin: '5px',borderRadius: '7px'}}></img>
                <span>
                    <div className='div-title'>{book.title}</div>
                    <div className='div-author'>{book.author}</div>
                    <div className='div-author'>public : {book.isPublic ? 'true': 'false'}</div>
                </span>
            </div>
            <div className='div-actions'>
                <EditBookModal book={book} handleFormSubmit={EditBook} show={show} handleClose={handleClose} />
                <Button className='btn btn-danger button-actions' onClick={() => DeleteBook(dispatch, book)}>Delete</Button>
            </div>
        </div>

    )
}

export const BookRow = ({ dispatch, book }) => {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return (
        <div className='div-book-row'>
            <div style ={{display:'flex'}}>
                <img src={image} width='150px' style ={{margin: '5px',borderRadius: '7px'}}></img>
                <span>
                    <div className='div-title'>{book.title}</div>
                    <div className='div-author'>{book.author}</div>
                    <div className='div-author'>Book was published by {book.holderName}</div>
                </span>
            </div>
            <div className='div-actions'>
                <Button className='btn btn-success button-actions'>Download</Button>
            </div>
        </div>

    )
}



