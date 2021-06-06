using BooksPF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksPF.Core.Abstract
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> AddBook(Book book);
        Task<Book> GetBookById(string id);
        Task DeleteBook(string id);
        Task<Book> UpdateBook(Book book);
    }
}
