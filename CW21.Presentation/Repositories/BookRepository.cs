using CW21.Presentation.Data;
using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Repositories;

public class BookRepository : IBookRepository
{
    private readonly  AppDbContext _dbContext;

    public BookRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _dbContext.Books
            //.Include(b => b.Category)
            //.Include(a=>a.Author)
            .ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Book>> GetAllBooksMoreThanPriceAsync(decimal price)
    {
        return await _dbContext.Books.Where(b=>b.Price>price).ToListAsync();
    }

    public async Task<List<Book>> GetAllBooksOrderByPriceAsync()
    {
        return await _dbContext.Books.OrderBy(b=>b.Price).ToListAsync();
    }

    public async Task DeleteBookAsync(Book book)
    {
          _dbContext.Books.Remove(book);
          await _dbContext.SaveChangesAsync();
    }

    public void AddBooksAndPrintSaveChange(List<Book> books)
    {
        _dbContext.Books.AddRange(books);

       var result = _dbContext.SaveChanges();
        Console.WriteLine($"savechange massege {result}");

        var emptyResult = _dbContext.SaveChanges();
        Console.WriteLine($"empty savechange massege {emptyResult}");
    }

    public async Task<List<Book>> ShowAllBookWhitInfo()
    {
        return await _dbContext.Books.AsNoTracking().Include(x => x.Author)
            .Include(x => x.Publisher)
            .Include(x => x.Category)
            .ToListAsync();

    }

    public async Task<List<Book>> FilterBooks()
    {
        var Avrage = await _dbContext.Books.AverageAsync(b => b.Price);
        return await _dbContext.Books
            .Where(b => b.Stock > 0 && b.Price > Avrage )
            .OrderByDescending(b => b.Price)    
            .ToListAsync();
    }


    public async Task BookStockUpdate(int bookId ,int newStock)
    {
        var book = await _dbContext.Books
              .FirstOrDefaultAsync(b => b.Id == bookId);
        if( book == null)
        {
            Console.WriteLine("Khalie");
            
        }
       book.Stock += newStock;
 
        
        await _dbContext.SaveChangesAsync();

        Console.WriteLine($"{book.Id} , {book.Title} , {book.Stock}");
            
    }

   
}