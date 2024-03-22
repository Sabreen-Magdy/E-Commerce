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
    public class CartItemConfiguration : IEntityTypeConfiguration<Domain.Entities.CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            #region Relationship Constrains
            builder.HasKey(ci => new { ci.CartId, ci.ProductVarientId });
            builder.HasOne(ci => ci.ProductVarient)
                   .WithMany(pv => pv.CartItems)
                   .HasForeignKey(pv => pv.ProductVarientId);
            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(c => c.CartId);
            #endregion
        }
    }
}
