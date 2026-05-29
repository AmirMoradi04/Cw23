using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Data.Configurations
{
    public class PublisherModelBuilderConfiguration : BaseModelBuilderConfiguration<Publisher>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<Publisher> modelBuilder)
        {
            modelBuilder.HasIndex(x => x.Name).IsUnique();

            modelBuilder.HasMany(b => b.Books)
            .WithOne(x => x.Publisher)
            .HasForeignKey(x => x.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

            modelBuilder.HasData(SeedData.SeedData.CreatePublisher);


        }
    }
}
