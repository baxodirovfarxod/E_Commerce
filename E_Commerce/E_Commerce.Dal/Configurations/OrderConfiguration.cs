using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Dal.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.OrderId);
        
        builder.Property(o => o.CustomerId)
               .IsRequired();

        builder.Property(o => o.CreatedAt)
               .IsRequired();

        builder.Property(o => o.TotalAmount)
              .IsRequired()
              .HasColumnType("decimal(18,2)");

        builder.Property(o => o.Discount)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(o => o.DiscountPercentage)
              .IsRequired();

        builder.Property(o => o.ServicePrice)
              .IsRequired()
              .HasColumnType("decimal(18,2)");
        
        builder.Property(o => o.Status)
              .IsRequired();
        
        builder.HasMany(o => o.Payments)
               .WithOne(p => p.Order)
               .HasForeignKey(p => p.OrderId);
    }
}
