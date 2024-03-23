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
    public class FavouriteConfigurations: IEntityTypeConfiguration<Domain.Entities.Favourite>
    {
     
    public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.Ignore(f=>f.Id);
            builder.HasKey(f => new { f.ProductVarientId, f.CustomerId });
            builder.HasOne(f => f.Customer)
                        .WithMany(c => c.Favourites)
                        .HasForeignKey(f => f.CustomerId);
            builder.HasOne(f => f.ProductVarients)
                        .WithMany(pv => pv.Favourites)
                        .HasForeignKey(f => f.ProductVarientId);

        }
    }
}
