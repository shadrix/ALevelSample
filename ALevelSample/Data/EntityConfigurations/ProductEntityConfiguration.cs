using ALevelSample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALevelSample.Data.EntityConfigurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Price).IsRequired();
    }
}