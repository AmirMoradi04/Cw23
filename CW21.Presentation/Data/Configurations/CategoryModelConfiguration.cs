using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW21.Presentation.Data.Configurations;

public class CategoryModelConfiguration : BaseModelBuilderConfiguration<Category>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Category> modelBuilder)
    {
        modelBuilder.Property(u => u.Name)
            .IsRequired();

      modelBuilder.HasIndex(u => u.Name)
            .IsUnique();   



        modelBuilder.Property(u => u.Description)
            .HasColumnType("nvarchar(400)")
            .IsRequired();

        modelBuilder.HasData(SeedData.SeedData.Categories);


    }
}