using CW21.DataAccess.Data.Dto;
using CW21.Presentation.Data;
using CW21.Presentation.Data.Dto;
using CW21.Presentation.Entities;
using CW21.Presentation.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Service
{
    public class BookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<viewBookModelDto>> GetAllBookServiceAsync()
        {
            var books = await _context.Books.AsNoTracking()
                 .Select(b => new viewBookModelDto
                 {
                     Title = b.Title,
                     Stock = b.Stock,
                     Price = b.Price,
                     AuthorName = b.Author.FullName,
                     CategoryName = b.Category.Name,
                     PublisherName = b.Publisher.Name,
                     TagName = b.Tags.Select(t => t.Name).ToList()

                 }
                ).ToListAsync();

            return books;
        }

        public async Task<List<RealBookDto>> GetBookByStock()
        {
            return await _context.Books.AsNoTracking().Where(x => x.Stock > 0)
                .Select(x => new RealBookDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Stock = x.Stock,
                    //Tags = x.Tags
                }).ToListAsync();
        }

        public async Task<BookDetailsDto> GetBookDetailsAsync(int bookId)
        {
            var books = await _context.Books.AsNoTracking()
                .Where(b => b.Id == bookId)
                .Select(b => new BookDetailsDto
                {
                    Title = b.Title,
                    Stock = b.Stock,
                    Price = b.Price,
                    PublisherName = b.Publisher.Name,
                    PublishYear = b.PublishYear,
                    AuthorName = b.Author.FullName,
                    CategoryName = b.Category.Name,
                    Tags = b.Tags.Select(t => t.Name).ToList()



                }).FirstOrDefaultAsync();
            return books;
        }

        public async Task<BookDetailsDto> GetBookByIdAsync(int id)
        {
           var book =  await _context.Books.AsNoTracking()
                .Where(b => b.Id == id)
                .Select(x => new BookDetailsDto
                {
                    Title = x.Title,
                    Price = x.Price,
                    AuthorName = x.Author.FullName,
                    CategoryName = x.Category.Name,
                    PublisherName = x.Publisher.Name,
                    PublishYear = x.PublishYear,
                    Stock = x.Stock,
                    Tags = x.Tags.Select(t => t.Name).ToList()
                }).FirstOrDefaultAsync();

            if (book is null)
                throw new NotFoundException("Book Not Found !");

            return book;
        }

        public async Task AddTagToBook(int bookId, int tagId)
        {
            var book = await _context.Books
                .Include(b => b.Tags)
                .FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null)
            {
                throw new Exception("dadash ketab peyda nashod");
            }

            var tag = await _context.Tags
                .FirstOrDefaultAsync(t => t.Id == tagId);
            if (tag == null)
            {
                throw new Exception("dadash tag nadarim ke");
            }

            if (book.Tags.Any(t => t.Id == tagId))
            {
                throw new Exception("dadash tekrarie in");
            }

            book.Tags.Add(tag);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveTagFromBook(int bookId, int tagId)
        {
            var book = await _context.Books
               .Include(b => b.Tags)
               .FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null)
            {
                throw new Exception("dadash ketab peyda nashod");
            }

            var tag = await _context.Tags
                .FirstOrDefaultAsync(t => t.Id == tagId);
            if (tag == null)
            {
                throw new Exception("dadash tag nadarim ke");
            }
            var bookTag = book.Tags.FirstOrDefault(x => x.Id == tagId);
            if (bookTag == null)
            {
                throw new Exception("nadare");
            }

            book.Tags.Remove(bookTag);
            await _context.SaveChangesAsync();
        }
    }
}
