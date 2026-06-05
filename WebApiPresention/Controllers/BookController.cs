using CW21.Presentation.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApiPresention.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        //public async Task<IActionResult> GetAllAsync()
        //{
        //    var books = await _bookService.GetAllBooksAsync();

        //    return Ok(books);
        //}
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await _bookService.GetAllBooksAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await _bookService.GetBookByIdAsync(id));

        [HttpGet("available")]
        public async Task<IActionResult> GetAllAvailableBooks() => Ok(await _bookService.GetBookByStock());

        //[HttpGet("available")]
        //public async Task<IActionResult> GetAllAvailableBooks() => Ok(await _bookService.GetBookByStock());
    }
}
