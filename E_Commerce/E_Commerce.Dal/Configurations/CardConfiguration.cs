using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Dal.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable("Cards");

        builder.HasKey(c => c.CardId);

        builder.Property(c => c.Number)
            .IsRequired()
            .HasMaxLength(16);

        builder.Property(c => c.HolderName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.ExpirationMonth)
            .IsRequired();

        builder.Property(c => c.ExpirationYear)
            .IsRequired();

        builder.Property(c => c.Cvv)
            .IsRequired()
            .HasMaxLength(4);

        builder.Property(c => c.SelectedForPayment)
            .IsRequired();
    }
}
