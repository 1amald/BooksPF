import React, { useState, useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { Form, Modal, Button, InputGroup, FormControl } from "react-bootstrap";
import { NewBook, EditBook } from '../services/books';

export const NewBookModal = () => {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return <div>
        <Button onClick={handleShow} className='btn btn-success'>New Book</Button>
        <BookModal note={null} handleFormSubmit={NewBook} show={show} handleClose={handleClose} />
    </div>
}

export const EditBookModal = ({ book }) => {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    return <div>
        <Button onClick={handleShow} className='btn btn-warning'>Edit</Button>
        <BookModal book={book} handleFormSubmit={EditBook} show={show} handleClose={handleClose} />
    </div>
}

const BookModal = ({ book, handleFormSubmit, show, handleClose }) => {
    const [modalBook, setModalBook] = useState({});
    const dispatch = useDispatch();

    useEffect(() => {
        setModalBook(book);
    }, [book]);

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Book heading</Modal.Title>
            </Modal.Header>
            <Form onSubmit={event => {
                event.preventDefault();
                handleFormSubmit(dispatch, modalBook);
            }}>
                <Modal.Body>
                    <InputGroup>
                        <FormControl value={modalBook === undefined ? '' : modalBook.title}
                            onChange={event => setModalBook({ ...modalBook, value: event.target.value })}/> 
                    </InputGroup>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
            </Button>
                    <Button type='submit' variant="primary" onClick={handleClose}>
                        Save
            </Button>
                </Modal.Footer>
            </Form>
        </Modal>
    );
}