using CW21.Presentation.Entities;

namespace CW21.Presentation;

public interface IAuthorRepository
{
    Task<List<Author>> GetAllAuthorsAsync();

    Task<List<Book>> GetBooksByAuthorIdAsync(int authorId);
}