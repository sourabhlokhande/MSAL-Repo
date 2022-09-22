using BookApi.Model;
using BookApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                IEnumerable<Books> booksData = await _bookService.GetBooks();
                return Ok(booksData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(Books book)
        {
            try
            {
                var result = await _bookService.AddBook(book);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook(Books book)
        {
            try
            {
                var result = await _bookService.UpdateBook(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteBook/{bookId:long}")]
        public async Task<IActionResult> DeleteBook(long bookId)
        {
            try
            {
                var result = await _bookService.DeleteBook(bookId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
