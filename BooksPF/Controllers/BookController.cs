﻿using BooksPF.Core.Abstract;
using BooksPF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BooksPF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookService.GetAllBooks();
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
            await bookService.UpdateBook(book);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            await bookService .DeleteBook(id);
            return Ok();
        }
    }
}
