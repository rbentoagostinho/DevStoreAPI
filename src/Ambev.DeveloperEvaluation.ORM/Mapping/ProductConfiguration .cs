using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Configuration class for the Product entity
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Category)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Image)
            .IsRequired()
            .HasMaxLength(200);

        builder.OwnsOne(p => p.Rating, rating =>
        {
            rating.Property(r => r.Rate)
                .IsRequired()
                .HasColumnType("decimal(3,2)");

            rating.Property(r => r.Count)
                .IsRequired();
        });

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(p => p.UpdatedAt)
            .IsRequired(false);
    }
}