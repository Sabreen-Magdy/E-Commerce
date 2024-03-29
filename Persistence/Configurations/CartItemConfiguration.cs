using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => new { ci.CustomerId, ci.ProductId, ci.SizeId, ci.ColorId });
            
            builder.Property(ci => ci.Id)
                .ValueGeneratedOnAddOrUpdate();
            builder.HasIndex(ci => ci.Id);

            builder.Ignore(c => c.TotalPrice);

            builder.Property(ci => ci.State);

            #region Relationship Constrains
            builder.HasOne(ci => ci.ProductVarient)
                   .WithMany(pv => pv.CartItems)
                   .HasForeignKey(pv => new { pv.ProductId, pv.SizeId, pv.ColorId });
            builder.HasOne(ci => ci.Customer)
                   .WithMany(c => c.Cart)
                   .HasForeignKey(c => c.CustomerId);
            #endregion
        }
    }
}
