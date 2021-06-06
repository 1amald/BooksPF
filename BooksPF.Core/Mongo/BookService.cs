using BooksPF.Core.Abstract;
using BooksPF.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksPF.Core.Mongo
{
    public class BookService: IBookService
    {
        private readonly IMongoCollection<Book> books;
        
        public BookService(IDbClient client)
        {
            books = client.GetBooksCollection();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await books.Find(_ => true).ToListAsync();
        }

        public async Task<Book> AddBook(Book book)
        {
            await books.InsertOneAsync(book);
            return book;
        }

        public async Task<Book> GetBookById(string id)
        {
            return await books.Find(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteBook(string id)
        {
            await books.DeleteOneAsync(b => b.Id == id);
        }

        public async Task<Book> UpdateBook(Book book)
        {
            await books.ReplaceOneAsync(b => b.Id == book.Id,book);
            return book;
        }
    }
}
