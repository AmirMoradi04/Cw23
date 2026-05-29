using CW21.Presentation.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Repositories
{
    public class BookStoreQueries
    {
        private readonly AppDbContext _context;

        public BookStoreQueries(AppDbContext context)
        {
            _context = context;
        }

        // 6. نمایش همه کتاب‌ها همراه با نویسنده و دسته‌بندی و موجودی
        public async Task ShowAllBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync();

            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author.FullName}," +
                    $" Category: {book.Category.Name}, Price: {book.Price}, Stock: {book.Stock}");
            }
        }

        // 7. کتاب‌های موجود در انبار (Stock > 0) مرتب‌شده نزولی بر اساس قیمت
        public async Task ShowAvailableBooksSortedByPriceDesc()
        {
            var books = await _context.Books
                .Where(b => b.Stock > 0)
                .OrderByDescending(b => b.Price)
                .ToListAsync();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.Price} (Stock: {book.Stock})");
            }
        }

        // 8. کتاب‌های منتشرشده بین 2010 تا 2020، مرتب‌شده بر اساس سال انتشار و سپس عنوان
        public async Task ShowBooksBetweenYears(int startYear, int endYear)
        {
            var books = await _context.Books
                .Where(b => b.PublishYear >= startYear && b.PublishYear <= endYear)
                .OrderBy(b => b.PublishYear)
                .ThenBy(b => b.Title)
                .ToListAsync();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.PublishYear} - {book.Title}");
            }
        }

        // 9. Projection به DTO ساده (فقط عنوان و نام نویسنده)
        public async Task ShowBookTitleAuthorProjection()
        {
            var result = await _context.Books
                .Select(b => new { b.Title, AuthorName = b.Author.FullName })
                .ToListAsync();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Title} - {item.AuthorName}");
            }
        }

        // 10. تغییر Stock یک کتاب
        public async Task UpdateBookStock(int bookId, int newStock)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                Console.WriteLine("کتاب پیدا نشد.");
                return;
            }

            book.Stock = newStock;
            await _context.SaveChangesAsync();
            Console.WriteLine($"موجودی کتاب {book.Title} به {newStock} تغییر یافت.");
        }

        // 11. فروش کتاب (کاهش موجودی)
        public async Task SellBook(int bookId, int count)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                Console.WriteLine("کتاب وجود ندارد.");
                return;
            }

            if (book.Stock < count)
            {
                Console.WriteLine("موجودی کافی نیست.");
                return;
            }

            book.Stock -= count;
            await _context.SaveChangesAsync();
            Console.WriteLine($"فروش موفق. {count} عدد از کتاب {book.Title} فروخته شد. موجودی جدید: {book.Stock}");
        }

        // 12. حذف کتاب
        public async Task DeleteBook(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                Console.WriteLine("کتاب یافت نشد.");
                return;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            Console.WriteLine("کتاب حذف شد.");

            int remainingCount = await _context.Books.CountAsync();
            Console.WriteLine($"تعداد کتاب‌های باقی‌مانده: {remainingCount}");
        }

        // 13. گزارش دسته‌بندی (تعداد کتاب‌ها و جمع موجودی هر دسته)
        public async Task CategoryStockReport()
        {
            var report = await _context.Books
                .GroupBy(b => b.Category.Name)
                .Select(g => new
                {
                    CategoryName = g.Key,
                    BooksCount = g.Count(),
                    TotalStock = g.Sum(b => b.Stock)
                })
                .ToListAsync();

            foreach (var item in report)
            {
                Console.WriteLine($"{item.CategoryName} - BooksCount: {item.BooksCount} - TotalStock: {item.TotalStock}");
            }
        }

        // 14. نویسندگانی که میانگین قیمت کتاب‌هایشان بالای 300000 است
        public async Task AuthorsWithHighAvgPrice(decimal threshold = 300000)
        {
            var result = await _context.Authors
                .Select(a => new
                {
                    AuthorName = a.FullName,
                    AveragePrice = a.Books.Average(b => b.Price)
                })
                .Where(x => x.AveragePrice > threshold)
                .ToListAsync();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.AuthorName} - Avg Price: {item.AveragePrice:N0}");
            }
        }

        // 15. گران‌ترین کتاب هر نویسنده
        public async Task MostExpensiveBookPerAuthor()
        {
            var query = _context.Authors
                .Select(a => new
                {
                    AuthorName = a.FullName,
                    TopBook = a.Books.OrderByDescending(b => b.Price).FirstOrDefault()
                })
                .Where(x => x.TopBook != null)
                .ToListAsync();

            var result = await query;

            foreach (var item in result)
            {
                Console.WriteLine($"{item.AuthorName} - {item.TopBook.Title} - {item.TopBook.Price}");
            }
        }
    }
}

