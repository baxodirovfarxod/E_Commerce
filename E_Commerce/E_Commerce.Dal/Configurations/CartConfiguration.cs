using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Dal.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(c => c.CartId);

        builder.Property(c => c.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(c => c.Customer)
            .WithOne(c => c.Cart)
            .HasForeignKey<Cart>(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
