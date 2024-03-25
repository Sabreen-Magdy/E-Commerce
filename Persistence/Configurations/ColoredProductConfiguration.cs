using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations;

public class ColoredProductConfiguration : IEntityTypeConfiguration<ColoredProduct>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ColoredProduct> builder)
    {
        // Primary Key
        builder.HasKey(e => new { e.ProductId, e.ColorId });
        builder.Property(e => e.Id)
                .ValueGeneratedOnAddOrUpdate();

        #region Not Mapped Properties

        builder.Ignore(p => p.TotalPrice);
        builder.Ignore(p => p.AvgPrice);
        builder.Ignore(p => p.TotalQuntity);

        #endregion

        #region Properties Constrains

        builder.Property(cp => cp.Image)
            .IsRequired();

        #endregion

        #region RelationShip Mapping

        builder.HasOne(cp => cp.Product)
            .WithMany(p => p.ColoredProducts)
            .HasForeignKey(cp => cp.ProductId);

        builder.HasOne(cp => cp.Color)
                  .WithMany(c => c.ColoredProducts)
                  .HasForeignKey(cp => cp.ColorId);

        #endregion
    }
}
