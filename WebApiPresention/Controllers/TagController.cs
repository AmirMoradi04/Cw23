using CW21.DataAccess.Data.Dto;
using CW21.Presentation.Data;
using CW21.Presentation.Entities;
using CW21.Presentation.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApiPresention.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly TagService  _tagService = new TagService(new AppDbContext());

        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var tags =await _tagService.GetAllTags();

            return Ok(tags);
            
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var tag = await _tagService.FindTagById(id);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);

        }

        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> GetBooksByTag(int id)
        //{
        //    var tag = await _tagService.GetBooksByTag(id);

        //    if (tag == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tag);

        //}

        [HttpPost(Name = "CreatTag")]
        public async Task<IActionResult> CreatTag([FromBody] string name)
        {
            await _tagService.CreateTag(name);

            return Created();
        }

        [HttpPost("AddTagToBookAmir")]
        public async Task<IActionResult> AddTagToBookAmir([FromBody]AddTagToBook2Dto request)
        {
            var check = await _tagService.AddTagToBook(request.TagId , request.BookId);
            if (!check)
            {
                return NotFound();
            }

            return Ok(check);
        }
        [HttpDelete("RemoveTagFromBook")]
        public async Task<IActionResult> RemoveTagFromBook([FromBody]AddTagToBook2Dto request)
        {
            var check = await _tagService.RemoveTagToBook(request.TagId , request.BookId);
            if (!check)
            {
                return NotFound();
            }

            return Ok(check);
        }


    }
}
