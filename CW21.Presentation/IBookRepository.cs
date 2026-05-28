using CW21.Presentation.Entities;

namespace CW21.Presentation;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<List<Book>> GetAllBooksMoreThanPriceAsync(decimal price);
    Task<List<Book>> GetAllBooksOrderByPriceAsync();
    Task DeleteBookAsync(Book book);
    void AddBooksAndPrintSaveChange(List<Book> books);
}