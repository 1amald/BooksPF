using BooksPF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksPF.Core.Abstract
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks(string customerName);
        Task<IEnumerable<Book>> GetUserBooks(string customerName);
        Task<Book> AddBook(Book book);
        Task<Book> GetBookById(string id);
        Task DeleteBook(Book book);
        Task<Book> UpdateBook(Book book);
    }
}
