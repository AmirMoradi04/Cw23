using CW21.Presentation.Data;
using CW21.Presentation.Data.Dto;
using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Repositories
{
    public class PublisherRepository
    {
        private readonly AppDbContext _dbContext;

        public PublisherRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Publisher>> ShowAllPublisherInfo()
        {
            return await _dbContext.Publishers.AsNoTracking()
                .Include(p => p.Books)
                .ToListAsync();
        }

        public async Task<List<PublisherInfo>> ShowAllPublishersWith2Books()
        {
            return await _dbContext.Publishers.AsNoTracking()
                .Where(p => p.Books.Count() >= 2 )
                .Select(p => new PublisherInfo
                {
                   publisherName = p.Name,
                   bookCount = p.Books.Count()

                })
                .ToListAsync();
        }

        public async Task<List<PublisherBookInfoDto>> ShowInfoPublisherDto()
        {
            return await _dbContext.Publishers.AsNoTracking()

                .Select(p => new PublisherBookInfoDto
                {
                   PublisherName = p.Name,

                   BookCount = p.Books.Count(),

                   SumBook =p.Books.Sum(b => b.Stock),

                   AveragePriceBook = p.Books.Average(b => b.Price)

                }).ToListAsync();
                
        }

        public async Task<List<MaxPricePublisherBookDto>> MaxPricePublisherBook()
        {
            return await _dbContext.Publishers.AsNoTracking()
                .Select (p => new MaxPricePublisherBookDto
                {
                    publisherName = p.Name,
                    price =p.Books.Max(b => b.Price),
                    bookTitle = p.Books.OrderByDescending(b => b.Price).FirstOrDefault().Title


                }).ToListAsync ();  
        }

        public async Task BookPublisherUpdate(int bookId, int publisherId)
        {
            try
            {

                var book = await _dbContext.Books
                      .FirstOrDefaultAsync(b => b.Id == bookId);

                var publisher = await _dbContext.Publishers
                    .FirstOrDefaultAsync(b => b.Id == publisherId);

                if (publisher == null || book == null)
                {
                    throw new Exception();
                }
                book.PublisherId = publisherId;

                await _dbContext.SaveChangesAsync();

                Console.WriteLine($"{book.Id} , {book.Title} , {book.Publisher.Name}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async Task DeletePublisher(int publisherId)
        {
            var publisher = await _dbContext.Publishers
                .Include(p => p.Books)
                .FirstOrDefaultAsync(p => p.Id == publisherId);

            if (publisher == null)
            {
                Console.WriteLine("publisher Not Exist");
                return;
            }

            if (publisher.Books.Any())
            {
                Console.WriteLine("publisher book dare nemishe hazf kard");
                return;
            }

            _dbContext.Publishers.Remove(publisher);
            await _dbContext.SaveChangesAsync();

            int PublisherCount = await _dbContext.Publishers.CountAsync();
            Console.WriteLine($"Count Publisher : {PublisherCount}");
        }

    }
}
