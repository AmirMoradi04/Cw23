using CW21.Presentation.Data;
using CW21.Presentation.Data.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Service
{
    public class AuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuthorNameDto>> GetAllAuthors()
        {
            return await _context.Authors
                .AsNoTracking()
                .Select(x => new AuthorNameDto
                {
                    AuthorName = x.FullName
                }).ToListAsync();
        }

        public async Task<List<AuthorDto>> GetAuthorByBooksCount()
        {
            return await _context.Authors
                .AsNoTracking()
                .Select(x => new AuthorDto
                {
                    Id = x.Id,
                    AuthorName = x.FullName,
                    BookCount = x.Books.Count()
                }).ToListAsync();
        }

        public async Task<AuthorByIdDto?> GetAuthorById(int id)
        {
            return await _context.Authors
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Select(x => new AuthorByIdDto(x.Id, x.FullName)
                ).FirstOrDefaultAsync();
        }

        public async Task<List<BooksByTagDto>> GetAllBooks(int authorId)
        {
            return await _context.Books
                .AsNoTracking()
                .Where(b => b.AuthorId == authorId)
                .Select(x => new BooksByTagDto
                {
                    TitleBook = x.Title,
                    AuterName = x.Author.FullName,
                    Price = x.Price
                }).ToListAsync();
        }

        public async Task<List<AuthorDto>> GetBooksMore2()
        {
            return await _context.Authors
                .AsNoTracking()
                .Where(a => a.Books.Count > 2)
                .Select(x => new AuthorDto
                {
                    Id = x.Id,
                    AuthorName = x.FullName,
                    BookCount = x.Books.Count()
                }).ToListAsync();
        }

        public async Task<List<AuthorByIdDto>> GetAuthorByName(string name)
        {
            return await _context.Authors
                .AsNoTracking()
                .Where(a => a.FullName == name)
                .Select(x => new AuthorByIdDto(x.Id, x.FullName))
                .ToListAsync();
        }
    }
}
