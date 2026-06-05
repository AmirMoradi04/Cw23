using CW21.Presentation.Data;
using CW21.Presentation.Data.Dto;
using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Service
{
    public class TagService
    {
        private readonly AppDbContext _context;

        public TagService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AllTagsDto>> GetAllTags()
        {
            return await _context.Tags
            .Select(x => new AllTagsDto
            {
                TagId = x.Id,
                TagName = x.Name,
                BookCount = x.Books.Count,
            })
            .ToListAsync();
        }

        //public async Task<List<BooksByTagDto>> GetBooksByTag(int tagId)
        //{
        //    return await _context.Books.AsNoTracking()
        //        .Where(x => x.Id == tagId)
        //   .Select(x => new BooksByTagDto
        //   {
        //       TitleBook = x.Title,
        //       AuterName =x.Author.FullName,
        //       Price =x.Price
              
        //   })
        //   .ToListAsync();
        //}

        public async Task<List<BooksByTagDto>> GetBooksByTag(int tagId)
        {
            return (await _context.Tags.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == tagId)).Books
                            .Select(x => new BooksByTagDto
                            {
                                TitleBook = x.Title,
                                AuterName = x.Author.FullName,
                                Price = x.Price
                            })
                            .ToList();
        }

        public async Task CreateTag(string name)
        {  
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name)); 
            }
            var isTag = await _context.Tags.AnyAsync(x => x.Name == name);

            if (isTag)
            {
                throw new Exception("dadash hastesh");
            }

            var tag = new Tag
            {
                Name = name
            };

            await _context.Tags.AddAsync(tag);

            await _context.SaveChangesAsync();

            Console.WriteLine($"id : {tag.Id} , name : {tag.Name} ");
        }
    }
}
