using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Dal.Configurations;

public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>

{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder.ToTable("OrderProducts");

        builder.HasKey(op => new { op.OrderId, op.ProductId });

        builder.Property(op => op.Quantity)
            .IsRequired();

        builder.Property(op => op.PriceAtPurchase)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
