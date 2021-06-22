import React from 'react';
import './App.css';
import { BrowserRouter, Route } from 'react-router-dom';
import { MyBooks,AllBooks } from './components/BookLibrary';
import { LoginForm } from './components/LoginForm';
import { RegisterForm } from './components/RegisterForm';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <div className='content'>
          <Route path="/my" component={MyBooks} />
          <Route path="/library" component={AllBooks} />
          <Route path="/login" component={LoginForm} />
          <Route path="/register" component={RegisterForm} />
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;
