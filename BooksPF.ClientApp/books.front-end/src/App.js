import React from 'react';
import './App.css';
import { BooksTable } from './components/BooksTable';
import {NewBookModal} from './components/BookModal';

function App() {
  return (
    <div className="App">
      <div className ='content'>
        <NewBookModal />
        <BooksTable/>
      </div>
    </div>
  );
}

export default App;
