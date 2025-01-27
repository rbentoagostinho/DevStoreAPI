using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Configuration class for the Sale entity
    /// </summary>
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired()
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.SaleNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.SaleDate)
                .IsRequired()
                .HasColumnType("timestamp");

            builder.Property(s => s.CustomerId)
                .IsRequired();

            builder.Property(s => s.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Branch)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.IsCancelled)
                .IsRequired();

            builder.HasMany(s => s.Items)
                .WithOne()
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
          

            // Trigger calculation of TotalAmount when saving changes
            builder.Property(s => s.TotalAmount)
                .HasComputedColumnSql("dbo.CalculateTotalAmount(Items)");

            // Optionally, you can add a custom SQL function to calculate the total amount
            // if the logic of TotalAmount is complex and cannot be handled directly by EF Core.
        }
    }
}
