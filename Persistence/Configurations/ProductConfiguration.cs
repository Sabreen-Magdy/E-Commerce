using Microsoft.EntityFrameworkCore;
using Domain.Enums;
using Domain.Entities;

namespace Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
    {
        // Primary Key
        builder.HasKey(e => e.Id);

        #region Not Mapped Properties

        builder.Ignore(p => p.TotalQuantity);
        builder.Ignore(p => p.TotalPrice);
        builder.Ignore(p => p.AvgPrice);

        #endregion

        #region Properties Constrains

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsUnicode(true)
            .IsRequired();
        builder.Property(p => p.Description)
            .IsUnicode(true);
        builder.Property(p => p.AddingDate)
            .HasDefaultValueSql("GetDate()")
            .IsRequired();

        #endregion

        #region RelationShip Mapping

        builder.HasOne(p => p.Saller)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SallerId);

        #endregion

        #region Other Constraints

        //builder.ToTable(b =>
        //    b.HasCheckConstraint("AddingDateValidation",
        //    Unity.CheckDate($"[{Properties.AddingDate}]")));

        builder.ToTable(b => b
            .HasCheckConstraint("NumberReviewsValidation",
                $"[{Properties.NumberReviews}] >= 0"));

        builder.ToTable(b =>
            b.HasCheckConstraint("AvgRateValidation",
                $"[{Properties.AvgRate}] >= 0 and [{Properties.AvgRate}] <= 5 "));

        #endregion

    }
}
