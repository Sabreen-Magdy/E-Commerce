using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations;

public class ProductVarientConfiguration : IEntityTypeConfiguration<ProductVarient>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductVarient> builder)
    {
        // Primary Key
        builder.HasKey(e => new { e.ColoredProductId, e.SizeId });
        builder.Property(e => e.Id)
                .ValueGeneratedOnAddOrUpdate();


        #region Properties Constrains

        builder.Property(pv => pv.Quantity)
            .IsRequired();
        builder.Property(pv => pv.UnitPrice)
            .IsRequired();

        #endregion

        #region RelationShip Mapping

        builder.HasOne(pv => pv.ColoredProduct)
            .WithMany(cp => cp.Varients)
            .HasForeignKey(pv => pv.ColoredProductId);


        builder.HasOne(pv => pv.Size)
            .WithMany(s => s.Varients)
            .HasForeignKey(pv => pv.SizeId);

        #endregion

        #region Other Constraints

        builder.ToTable(b =>
        b.HasCheckConstraint("QuantityValidation",
       $"[{Properties.Quantity}] >= 0"));

        builder.ToTable(b => b
            .HasCheckConstraint("UnitPriceValidation",
                $"[{Properties.UnitPrice}] >= 0"));

        builder.ToTable(b =>
            b.HasCheckConstraint("DiscountValidation",
                $"[{Properties.Discount}] >= 0 and [{Properties.Discount}] <= 1"));

        #endregion

    }
}
