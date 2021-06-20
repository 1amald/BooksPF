import { configureStore } from '@reduxjs/toolkit';
import BooksReducer from './booksReducer';

export const store = configureStore({
  reducer: {
    booksReducer: BooksReducer,
  },
});
