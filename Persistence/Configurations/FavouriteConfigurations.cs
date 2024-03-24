using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FavouriteConfigurations: IEntityTypeConfiguration<Favourite>
    {
     
    public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.Ignore(f=>f.Id);
            builder.HasKey(f => new { f.ProductId, f.CustomerId });
            builder.HasOne(f => f.Customer)
                        .WithMany(c => c.Favourites)
                        .HasForeignKey(f => f.CustomerId);
            builder.HasOne(f => f.Product)
                        .WithMany(pv => pv.Favourites)
                        .HasForeignKey(f => f.ProductId);

        }
    }
}
