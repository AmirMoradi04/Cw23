//using System.Reflection;
//using CW21.Presentation.Data.Configurations;
//using CW21.Presentation.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace CW21.Presentation.Data;

//public class AppDbContext : DbContext
//{
//    public AppDbContext()
//    {
        
//    }

//    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//    {
        
//    }

//    public DbSet<Book> Books  { get; set; }
//    public DbSet<Author>Authors { get; set; }
//    public DbSet<Category> Categories {get; set;}
//    public DbSet<Publisher> Publishers {get; set;}
//    public DbSet<Tag> Tags {get; set;}

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
//    }
    
//}