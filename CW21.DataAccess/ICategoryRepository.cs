using CW21.Presentation.Entities;

namespace CW21.Presentation.Repositories;

public interface ICategoryRepository
{
    Task<List<Book>> GetBooksByCategoryIdAsync(int categoryId);
}