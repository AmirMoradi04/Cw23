//using CW21.DataAccess.Data.Dto;
//using CW21.Presentation.Data;
//using CW21.Presentation.Data.Dto;
//using CW21.Presentation.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Text;

//namespace CW21.Presentation.Service
//{
//    public class BookService
//    {
//        private readonly AppDbContext _context;

//        public BookService(AppDbContext context)
//        {
//            _context = context;
//        }
//        #region CW21
//        /// <summary>
//        /// CW24 
//        /// </summary>
//        /// <returns></returns>
//        public async Task<List<viewBookModelDto>> GetAllBookServiceAsync()
//        {
//            var books = await _context.Books.AsNoTracking()
//                 .Select(b => new viewBookModelDto
//                 {
//                     Title = b.Title,
//                     Stock = b.Stock,
//                     Price = b.Price,
//                     AuthorName = b.Author.FullName,
//                     CategoryName = b.Category.Name,
//                     PublisherName = b.Publisher.Name,
//                     TagName = b.Tags.Select(t => t.Name).ToList()

//                 }
//                ).ToListAsync();

//            return books;
//        }

//        public async Task<BookDetailsDto> GetBookDetailsAsync(int bookId)
//        {
//            var books = await _context.Books.AsNoTracking()
//                .Where(b => b.Id == bookId)
//                .Select(b => new BookDetailsDto
//                {
//                    Title = b.Title,
//                    Stock = b.Stock,
//                    Price = b.Price,
//                    PublisherName = b.Publisher.Name,
//                    PublishYear = b.PublishYear,
//                    AuthorName = b.Author.FullName,
//                    CategoryName = b.Category.Name,
//                    Tags = b.Tags.Select(t => t.Name).ToList()



//                }).FirstOrDefaultAsync();
//            return books;
//        }

//        public async Task AddTagToBook(int bookId, int tagId)
//        {
//            var book = await _context.Books
//                .Include(b => b.Tags)
//                .FirstOrDefaultAsync(b => b.Id == bookId);
//            if (book == null)
//            {
//                throw new Exception("dadash ketab peyda nashod");
//            }

//            var tag = await _context.Tags
//                .FirstOrDefaultAsync(t => t.Id == tagId);
//            if (tag == null)
//            {
//                throw new Exception("dadash tag nadarim ke");
//            }

//            if (book.Tags.Any(t => t.Id == tagId))
//            {
//                throw new Exception("dadash tekrarie in");
//            }

//            book.Tags.Add(tag);

//            await _context.SaveChangesAsync();
//        }

//        public async Task RemoveTagFromBook(int bookId, int tagId)
//        {
//            var book = await _context.Books
//               .Include(b => b.Tags)
//               .FirstOrDefaultAsync(b => b.Id == bookId);
//            if (book == null)
//            {
//                throw new Exception("dadash ketab peyda nashod");
//            }

//            var tag = await _context.Tags
//                .FirstOrDefaultAsync(t => t.Id == tagId);
//            if (tag == null)
//            {
//                throw new Exception("dadash tag nadarim ke");
//            }
//            var bookTag = book.Tags.FirstOrDefault(x => x.Id == tagId);
//            if (bookTag == null)
//            {
//                throw new Exception("nadare");
//            }

//            book.Tags.Remove(bookTag);
//            await _context.SaveChangesAsync();
//        }
//        #endregion

//        #region MainMethods
//        public async Task<List<Book>> GetAllBooksAsync()
//        {
//            return await _context.Books
//                //.Include(b => b.Category)
//                //.Include(a => a.Author)
//                .ToListAsync();
//        }

//        public async Task<Book?> GetBookByIdAsync(int id)
//        {
//            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
//        }

//        public async Task<List<Book>> GetAllBooksMoreThanPriceAsync(decimal price)
//        {
//            return await _context.Books.Where(b => b.Price > price).ToListAsync();
//        }

//        public async Task<List<Book>> GetAllBooksOrderByPriceAsync()
//        {
//            return await _context.Books.OrderBy(b => b.Price).ToListAsync();
//        }

//        public async Task DeleteBookAsync(Book book)
//        {
//            _context.Books.Remove(book);
//            await _context.SaveChangesAsync();
//        }

//        public void AddBooksAndPrintSaveChange(List<Book> books)
//        {
//            _context.Books.AddRange(books);

//            var result = _context.SaveChanges();
//            Console.WriteLine($"savechange massege {result}");

//            var emptyResult = _context.SaveChanges();
//            Console.WriteLine($"empty savechange massege {emptyResult}");
//        }

//        public async Task<List<Book>> ShowAllBookWhitInfo()
//        {
//            return await _context.Books.AsNoTracking().Include(b => b.Author)
//                .Include(b => b.Category)
//                .Include(b => b.Publisher)
//                .ToListAsync();
//        }

//        public async Task<List<Book>> FilterBooks()
//        {
//            var Avrage = await _context.Books.AverageAsync(b => b.Price);
//            return await _context.Books
//                .Where(b => b.Stock > 0 && b.Price > Avrage)
//                .OrderByDescending(b => b.Price)
//                .ToListAsync();
//        }


//        public async Task BookStockUpdate(int bookId, int newStock)
//        {
//            var book = await _context.Books
//                  .FirstOrDefaultAsync(b => b.Id == bookId);
//            if (book == null)
//            {
//                Console.WriteLine("Khalie");
//            }
//            book.Stock += newStock;


//            await _context.SaveChangesAsync();

//            Console.WriteLine($"{book.Id} , {book.Title} , {book.Stock}");

//        }

//        #endregion

//        public async Task<List<ShowBookInfoDto>> ShowBookDetails()
//        {
//            return await _context.Books.AsNoTracking()
//                .Select(x => new ShowBookInfoDto
//                {
//                    Id = x.Id,
//                    Title = x.Title,
//                    AuthorName = x.Author.FullName,
//                    CategoryName = x.Category.Name,
//                    PublisherName = x.Publisher.Name,
//                    Tags = x.Tags.Select(t => t.Name).ToList()
//                }).ToListAsync();
//        }

//        public async Task<RealBookDto?> GetBookById(int id)
//        {
//            return await _context.Books.AsNoTracking()
//                .Select(x => new RealBookDto
//                {
//                    Id = x.Id,
//                    Title = x.Title,
//                    Price = x.Price,
//                    Stock = x.Stock,
//                    Tags = x.Tags
//                }).FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public async Task<List<RealBookDto>> GetBookByStock()
//        {
//            return await _context.Books.AsNoTracking().Where(x => x.Stock > 0)
//                .Select(x => new RealBookDto
//                {
//                    Id = x.Id,
//                    Title = x.Title,
//                    Price = x.Price,
//                    Stock = x.Stock,
//                    Tags = x.Tags
//                }).ToListAsync();
//        }

//        public async Task<List<SearchBooksByTitleDto>> GetBookByTitle(string title)
//        {
//            return await _context.Books.AsNoTracking().Where(x => x.Title == title)
//                .Select(x => new SearchBooksByTitleDto
//                {
//                    Id = x.Id,
//                    Title = x.Title,
//                    CategoryName = x.Category.Name,
//                    PublisherName = x.Publisher.Name,
//                    AuthorName = x.Author.FullName,
//                    CategoryId = x.CategoryId,
//                    PublisherId = x.PublisherId
//                }).ToListAsync();
//        }

//        public async Task<List<SearchBooksByTitleDto>> GetBookByCategory(int categoryId)
//        {
//            return await _context.Books.AsNoTracking().Where(x => x.CategoryId == categoryId)
//                .Select(x => new SearchBooksByTitleDto
//                {
//                    Id = x.Id,
//                    Title = x.Title,
//                    CategoryName = x.Category.Name,
//                    PublisherName = x.Publisher.Name,
//                    AuthorName = x.Author.FullName,
//                    CategoryId = x.CategoryId,
//                    PublisherId = x.PublisherId
//                }).ToListAsync();
//        }

//        public async Task<List<SearchBooksByTitleDto>> GetBookByAuthor(int authorId)
//        {
//            return await _context.Books.AsNoTracking().Where(x => x.AuthorId == authorId)
//                .Select(x => new SearchBooksByTitleDto
//                {
//                    Id = x.Id,
//                    Title = x.Title,
//                    CategoryName = x.Category.Name,
//                    PublisherName = x.Publisher.Name,
//                    AuthorName = x.Author.FullName,
//                    CategoryId = x.CategoryId,
//                    PublisherId = x.PublisherId

//                }).ToListAsync();
//        }

//        public async Task<List<SearchBooksByTitleDto>> GetBookByPublisher(int publisherId)
//        {
//            return await _context.Books.AsNoTracking().Where(x => x.PublisherId == publisherId)
//                .Select(x => new SearchBooksByTitleDto
//                {
//                    Id = x.Id,
//                    Title = x.Title,
//                    CategoryName = x.Category.Name,
//                    PublisherName = x.Publisher.Name,
//                    AuthorName = x.Author.FullName,
//                    CategoryId = x.CategoryId,
//                    PublisherId = x.PublisherId

//                }).ToListAsync();
//        }

//        public List<BookDetailsDto> GetBooksByTagId(int tagId)
//        {
//            var foundTags = _context.Tags.AsNoTracking().
//                FirstOrDefault(x => x.Id == tagId);

//            if (foundTags is not null)
//            {
//                return foundTags.Books.Select(x => new BookDetailsDto
//                {
//                    Title = x.Title,
//                    Price = x.Price,
//                    Stock = x.Stock,
//                    AuthorName = x.Author.FullName,
//                    PublisherName = x.Publisher.Name,
//                    CategoryName = x.Category.Name,
//                    PublishYear = x.PublishYear
//                }).ToList();
//            }

//            throw new Exception("No Tags Found !!");
//        }

//        public async Task<List<RealBookDto>> GetBooksByRangeOfPrice(decimal minPrice, decimal maxPrice)
//        {
//            return await _context.Books.AsNoTracking()
//                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
//                .Select(x => new RealBookDto
//                {
//                    Id = x.Id,
//                    Price = x.Price,
//                    Stock = x.Stock,
//                    Title = x.Title
//                }).ToListAsync();
//        }

//        public async Task<List<RealBookDto>> GetBooksByRangeOfPublisherYear(int publisherYear)
//        {
//            return await _context.Books.AsNoTracking()
//                .Where(x => x.PublishYear == publisherYear)
//                .Select(x => new RealBookDto
//                {
//                    Id = x.Id,
//                    Price = x.Price,
//                    Stock = x.Stock,
//                    Title = x.Title,
//                }).ToListAsync();
//        }


//    }
//}
