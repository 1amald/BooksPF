import React, { useState } from 'react';
import { Form, Modal, Button } from "react-bootstrap";

export function RegisterForm() {
    const [login, setLogin] = useState();
    const [password, setPassword] = useState();

    return (
            <div className='login-div'>
                <Form>
                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Login</Form.Label>
                        <Form.Control type="text" placeholder="Enter login" />
                    </Form.Group>
                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" placeholder="Password" />
                    </Form.Group>
                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Confirm Password</Form.Label>
                        <Form.Control type="password" placeholder="Confirm password" />
                    </Form.Group>
                    <Button variant="primary" type="submit" style={{ width: '100%' }}>
                        Submit
                    </Button>
                </Form>
            </div>
    )
}