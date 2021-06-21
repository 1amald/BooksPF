import { directive } from '@babel/types';
import React, { useState } from 'react';
import { FormControl } from 'react-bootstrap';


export function LoginForm() {
    const [login, setLogin] = useState();
    const [password, setPassword] = useState();

    return (
        <div style={{maxWidth: '50%',marginTop = '300px'}}>
            <Form onSubmit={event => {
                (dispatch, {login,password});
            }}>
            <Form.Group controlId="formBasicEmail">
                <Form.Label>Login</Form.Label>
                <Form.Control type="text" placeholder="Enter login" />
                <Form.Text className="text-muted">
                    We'll never share your email with anyone else.
                </Form.Text>
            </Form.Group>
            <Form.Group controlId="formBasicPassword">
                <Form.Label>Password</Form.Label>
                <Form.Control type="password" placeholder="Password"/>
            </Form.Group>
            <Button variant="primary" type="submit">
                Submit
            </Button>
        </Form>
        </div>
    )
}