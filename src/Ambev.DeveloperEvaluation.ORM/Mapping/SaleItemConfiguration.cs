using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Configuration class for the SaleItem entity
    /// </summary>
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(si => si.Id);

            builder.Property(si => si.Id)
                .IsRequired()
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(si => si.SaleId)
                .IsRequired();

            builder.Property(si => si.ProductId)
                .IsRequired();

            builder.Property(si => si.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(si => si.Quantity)
                .IsRequired();

            builder.Property(si => si.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(si => si.Discount)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(si => si.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne<Sale>()
                .WithMany(s => s.Items)
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Optionally, you can add a computed column or custom logic to calculate the total price
            builder.Property(si => si.TotalPrice)
                .HasComputedColumnSql("dbo.CalculateSaleItemTotalPrice(Quantity, UnitPrice, Discount)");
        }
    }
}
