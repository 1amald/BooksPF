using BooksPF.Core.Abstract;
using BooksPF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BooksPF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var result = await bookService.AddBook(book);
            return Ok(result);
        }

        [HttpGet("{id}",Name = "GetBook")]
        public async Task<IActionResult> GetBook(string id)
        {
            var book = await bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            await bookService.UpdateBook(book);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(string id)
        {
            await bookService .DeleteBook(id);
            return Ok();
        }
    }
}
