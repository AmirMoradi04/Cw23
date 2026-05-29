using CW21.Presentation.Data;
using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<List<Book>> GetBooksByAuthorIdAsync(int authorId)
    {
        return await _context.Books
            .Where(b => b.AuthorId == authorId)
            .ToListAsync();
    }
}