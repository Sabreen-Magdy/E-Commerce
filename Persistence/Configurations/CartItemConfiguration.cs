using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => new { ci.CartId, ci.ProductId, ci.SizeId, ci.ColorId });
            
            builder.Ignore(c => c.TotalPrice);
           
            #region Relationship Constrains
            builder.HasOne(ci => ci.ProductVarient)
                   .WithMany(pv => pv.CartItems)
                   .HasForeignKey(pv => new { pv.ProductId, pv.SizeId, pv.ColorId });
            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(c => c.CartId);
            #endregion
        }
    }
}
