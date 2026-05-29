using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW21.Presentation.Data.Configurations;

public abstract class BaseModelBuilderConfiguration<T> :IEntityTypeConfiguration<T> where T : BaseEntity
{
   
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);


        ApplyEntityConfiguration(builder);
    }

    protected abstract void ApplyEntityConfiguration(EntityTypeBuilder<T> modelBuilder);
}