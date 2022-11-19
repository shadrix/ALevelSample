using ALevelSample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALevelSample.Data.EntityConfigurations;

public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItemEntity>
{
    public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(p => p.Count).IsRequired();
        builder.Property(p => p.OrderId).IsRequired();
        builder.Property(p => p.ProductId).IsRequired();

        builder.HasOne(h => h.Order)
            .WithMany(w => w.OrderItems)
            .HasForeignKey(h => h.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(h => h.Product)
            .WithMany(w => w.OrderItems)
            .HasForeignKey(h => h.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}