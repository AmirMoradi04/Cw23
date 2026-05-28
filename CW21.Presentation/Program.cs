// See https://aka.ms/new-console-template for more information

using CW21.Presentation.Data;
using CW21.Presentation.Entities;
using CW21.Presentation.Repositories;
using static System.Reflection.Metadata.BlobBuilder;

var context = new AppDbContext();
var bookRepo = new BookRepository(context);
var publisherRepo = new PublisherRepository(context);

//await bookRepo.BookStockUpdate(8, 10);

var publisher = await publisherRepo.MaxPricePublisherBook();
foreach(var item in publisher)
{
    Console.WriteLine($"{item.publisherName} , {item.price}");
}


//var result = await bookRepo.ShowAllBookWhitInfo();


//foreach (var item in result)
//{
//    Console.WriteLine($"{item.Price} , {item.Publisher.City}");
//}


//var book = await bookRepo.GetBookByIdAsync(2);
//if (book != null)
//{
//    await bookRepo.DeleteBookAsync(book);
//}

//await bookRepo.DeleteBookAsync(book);

//Console.WriteLine();


//var books = new List<Book>(){
//new Book
//{
//Title = "ASP.NET Core",
//Price = 650,
//Stock = 5,
//PublishYear = 2020,
//CreatedAt = DateTime.Now,
//AuthorId = 1,
//CategoryId = 1
//},
//new Book
//{
//Title = "Entity Framework Core",
//Price = 720,
//Stock = 8,
//PublishYear = 2021,
//CreatedAt = DateTime.Now,
//AuthorId = 2,
//CategoryId = 1
//}
//};

//bookRepo.AddBooksAndPrintSaveChange(books);