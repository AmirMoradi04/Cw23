using CW21.Presentation.Data.Dto;
using CW21.Presentation.Entities;
using CW21.Presentation.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPresention.DTO;

namespace WebApiPresention.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthors();

            if (!authors.Any())
                throw new Exception("Author Not Found !");

            return Ok(GenericResult<List<AuthorNameDto>>.Success(authors));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorById([FromRoute]int id)
        {
            var authors = await _authorService.GetAuthorById(id);

            if(authors == null)
                return NotFound();

            return Ok(authors);
        }

        [HttpGet("MoreThan2Books")]
        public async Task<IActionResult> GetAuthorsWithMoreThan2Books()
        {
            var authors = await _authorService.GetBooksMore2();

            if (!authors.Any())
                return NotFound();
            
            return Ok(authors);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> GetAuthorsByName([FromQuery]string name)
        {
            var authors = await _authorService.GetAuthorByName(name);

            if (!authors.Any())
                return NotFound();
            
            return Ok(authors);
        }
    }
}
