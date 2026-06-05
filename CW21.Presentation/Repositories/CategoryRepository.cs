using CW21.Presentation.Data;
using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetBooksByCategoryIdAsync(int categoryId)
    {
        return await _context.Books.AsNoTracking() //?????? ???? ??????? 
            .Where(b => b.CategoryId == categoryId)
            .ToListAsync();
    }


    public async Task<List<Category>> ShowAllCategoryInfo()
    {
        return await _context.Categories.AsNoTracking()
            .AsNoTracking()
            .Include(c => c.Books)
            .ThenInclude(b => b.Author)
            .ToListAsync();
    }

   
}