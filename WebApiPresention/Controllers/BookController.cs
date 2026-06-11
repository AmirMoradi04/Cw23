using CW21.Presentation.Data.Dto;
using CW21.Presentation.Service;
using Microsoft.AspNetCore.Mvc;
using WebApiPresention.DTO;

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
        public async Task<IActionResult> GetAllAsync() => Ok(await _bookService.GetAllBookServiceAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            return Ok(GenericResult<BookDetailsDto>.Success(book,"Found Successfully Dadash"));
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAllAvailableBooks() => Ok(await _bookService.GetBookByStock());

        //[HttpGet("available")]
        //public async Task<IActionResult> GetAllAvailableBooks() => Ok(await _bookService.GetBookByStock());
    }
}
