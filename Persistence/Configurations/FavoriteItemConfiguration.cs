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
    public class FavoriteItemConfiguration : IEntityTypeConfiguration<Domain.Entities.FavoriteItems>
    {
        public void Configure(EntityTypeBuilder<FavoriteItems> builder)
        {
            #region Relationship Constrains
            builder.HasKey(fi => new { fi.FavouriteId, fi.ProductVarientId });
            builder.HasOne(fi => fi.ProductVarient)
                   .WithMany(pv => pv.FavoriteItems)
                   .HasForeignKey(pv => pv.ProductVarientId);
            builder.HasOne(fi => fi.Favourite)
                   .WithMany(f => f.FavoriteItems)
                   .HasForeignKey(f => f.FavouriteId);
            #endregion
        }
    }
}
