using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW21.Presentation.Data.Configurations;

public class BookModelBuilderConfiguration : BaseModelBuilderConfiguration<Book>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Book> modelBuilder)
    {
        // modelBuilder.Property(u => u.Title)
        //     .HasColumnType("nvarchar(100)")
        //     .IsRequired();

        modelBuilder.Property(u => u.Price)
            .HasColumnType("decimal(10, 2)")
            .HasDefaultValue(0);
            
            
        //TODOO
        
        modelBuilder.Property(u => u.PublishYear)
            .IsRequired();

        modelBuilder.Property(u => u.CreatedAt)
            .IsRequired();
        
        modelBuilder.HasIndex(u => u.AuthorId)
            ;
        
        modelBuilder.HasIndex(u => u.CategoryId)
            ;

        modelBuilder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.HasOne(b => b.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Property(s => s.Stock)
            .IsRequired()
            .HasDefaultValue(0);

       modelBuilder.HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(x => x.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.HasMany(x => x.Tags)
                    .WithMany(x => x.Books)
                    .UsingEntity(j =>
                    {
                          j.ToTable("BookTags");
                          
                          j.HasData(
                          new { BooksId = 1, TagsId = 1 },
                          new { BooksId = 1, TagsId = 2 },
                          new { BooksId = 1, TagsId = 3 }
                        );
                    });

        modelBuilder.HasData(SeedData.SeedData.Books);
    }   
}