using System;
using System.Collections.Generic;
using System.Text;
using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW21.Presentation.Data.Configurations
{
    public class TagModelBuilderConfiguration : BaseModelBuilderConfiguration<Tag>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<Tag> modelBuilder)
        {
           modelBuilder.Property(t =>t.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.HasIndex(t => t.Name)
                .IsUnique();


            modelBuilder.HasData(SeedData.SeedData.CreateTag);

        }
    }
}
