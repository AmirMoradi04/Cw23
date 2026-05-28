using CW21.Presentation.Entities;

namespace CW21.Presentation.Data.SeedData;

public static class SeedData
{
    public static List<Tag> CreateTag => new()
    {
        new Tag
        {
            Id = 1,
            Name = "Programming",
            CreatedAt = new DateTime(2026,05,01)

        },
        new Tag
        {
            Id = 2,
            Name = "Database",
            CreatedAt = new DateTime(2026,06,05)

        },
        new Tag
        {
            Id = 3,
            Name = "Backend",
            CreatedAt = new DateTime(2026,04,01)

        }
    };
    public static List<Publisher> CreatePublisher => new()
    {
        new Publisher
        {
            Id = 1,
            Name = "dastayofski",  
            City="mosko",
            PhoneNumber="9125846565",
            CreatedAt =new DateTime(2000,05,01),


        },
        new Publisher
        {
            Id = 2,
            Name = "mohamad",  
            City="tehran",
            PhoneNumber="9125846565",
            CreatedAt =new DateTime(2000,05,01),


        },
        new Publisher
        {
            Id = 3,
            Name = "akbari",  
            City="shiraz",
            PhoneNumber="9125846565",
            CreatedAt =new DateTime(2000,05,01),


        },
        new Publisher
        {
            Id = 4,
            Name = "roham",  
            City="tehran",
            PhoneNumber="9125846565",
            CreatedAt =new DateTime(2000,05,01),


        }

    };
   public static List<Author> CreateAuthors => new()
   {
      new Author
      {
         Id = 1,
         FullName = "Robert C. Martin",
         BirthDate = new DateTime(1952, 12, 5),
         Country = "USA"
      },
      new Author
      {
         Id = 2,
         FullName = "Jon Skeet",
         BirthDate = new DateTime(1976, 6, 19),
         Country = "UK"
      },
      new Author
      {
         Id = 3,
         FullName = "James Clear",
         BirthDate = new DateTime(1986, 1, 22),
         Country = "USA"
      }
   };
   public static List<Category> Categories => new()
   {
      new Category
      {
         Id = 1,
         Name = "Programming",
         Description = "Programming and software engineering books"
      },
      new Category
      {
         Id = 2,
         Name = "Self Development",
         Description = "Personal growth books"
      },
      new Category
      {
         Id = 3,
         Name = "Productivity",
         Description = "Focus and productivity books"
      }
   };

   public static List<Book> Books => new()
   {
      new Book
      {
         Id = 1,
         PublisherId =2,
         Title = "Clean Code",
         Price = 700,
         PublishYear = 2008,
         CreatedAt = new DateTime(2024, 1, 1),
         AuthorId = 1,
         CategoryId = 1
      },
      new Book
      {
         Id = 2,
         PublisherId =2,
         Title = "C# In Depth",
         Price = 850,
         PublishYear = 2019,
         CreatedAt = new DateTime(2024, 1, 2),
         AuthorId = 2,
         CategoryId = 1
      },
      new Book
      {
         Id = 3,
          PublisherId =1,
         Title = "Atomic Habits",
         Price = 450,
         PublishYear = 2018,
         CreatedAt = new DateTime(2024, 1, 3),
         AuthorId = 3,
         CategoryId = 2
      },
      new Book
      {
         Id = 4,
          PublisherId =3,
         Title = "The Pragmatic Programmer",
         Price = 900,
         PublishYear = 1999,
         CreatedAt = new DateTime(2024, 1, 4),
         AuthorId = 1,
         CategoryId = 1
      },
      new Book
      {
         Id = 5,
          PublisherId =2,
         Title = "Deep Work",
         Price = 500,
         PublishYear = 2016,
         CreatedAt = new DateTime(2024, 1, 5),
         AuthorId = 3,
         CategoryId = 3
      }
      ,
      new Book
      {
          Id = 6,
           PublisherId =4,
          Title = "maktab",
          Price = 550,
          PublishYear = 1500,
          CreatedAt = new DateTime(2025, 10, 2),
          AuthorId = 3, 
          CategoryId = 3 ,

          Stock = 5
      },
      new Book
      {
          Id = 7,
           PublisherId =1,
          Title = "maktab2",
          Price = 600,
          PublishYear = 15000,
          CreatedAt = new DateTime(2025, 10, 2),
          AuthorId = 3, 
          CategoryId = 3 ,

          Stock = 6
      },
      new Book
      {
          Id = 8,
           PublisherId =1,
          Title = "maktab3",
          Price = 700,
          PublishYear = 2000,
          CreatedAt = new DateTime(2025, 10, 2),
          AuthorId = 3, 
          CategoryId = 3 ,

          Stock = 17
      },
      new Book
      {
          Id = 9,
           PublisherId =4,
          Title = "maktab4",
          Price = 750,
          PublishYear = 2010,
          CreatedAt = new DateTime(2025, 10, 2),
          AuthorId = 3, 
          CategoryId = 3,
          Stock = 0
      },
      new Book
      {
          Id = 10,
          PublisherId =1,
          Title = "maktab5",
          Price = 760,
          PublishYear = 2025,
          CreatedAt = new DateTime(2025, 10, 2),
          AuthorId = 3, 
          CategoryId = 3 ,
          Stock = 0
      },

       new Book
      {
         Id = 20,
         PublisherId =2,
         Title = "EF Core Guide",
         Price = 10000000,
         PublishYear = 2026,
         CreatedAt = new DateTime(2026, 1, 1),
         AuthorId = 1,
         CategoryId = 1,
         
      }
   };

   
}