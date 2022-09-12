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
        public IActionResult GetBooks()
        {
            try
            {
                IEnumerable<Books> booksData = _bookService.GetBooks();
                return Ok(booksData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(Books book)
        {
            try
            {
                var result = _bookService.AddBook(book);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(Books book)
        {
            try
            {
                var result = _bookService.UpdateBook(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteBook/{bookId:long}")]
        public IActionResult DeleteBook(long bookId)
        {
            try
            {
                var result = _bookService.DeleteBook(bookId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
