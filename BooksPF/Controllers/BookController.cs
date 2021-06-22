using BooksPF.Core.Abstract;
using BooksPF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace BooksPF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IFileService fileService;
        public BookController(IBookService bookService,IFileService fileService)
        {
            this.bookService = bookService;
            this.fileService = fileService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllBooks()
        {
            var customerName = User.Identity.Name;
            var books = await bookService.GetAllBooks(customerName);
            return Ok(books);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBook(Book book)
        {
            book.HolderName = User.Identity.Name;
            var result = await bookService.AddBook(book);
            return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            if(User.Identity.Name != book.HolderName)
            {
                return Forbid();
            }
            var updatedBook = await bookService.UpdateBook(book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBook(Book book)
        {
            if(User.Identity.Name != book.HolderName)
            {
                return Forbid();
            }
            await bookService.DeleteBook(book);
            return Ok();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var e = await fileService.UploadFile(file);
            return Ok(e.ToString());
        }
        [HttpPost("download")]
        public async Task<IActionResult> DownloadFile(DownloadRequest req)
        {
            var contentType = "text/plain";
            var downloadBytes = await fileService.DownloadFile(req.FileId);
            return File(downloadBytes, contentType);
        }

        public class DownloadRequest
        {
            public string FileId { get; set; }
        }
    }
}
