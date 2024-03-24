using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Configurations
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Ignore(c => c.TotalPrice);
            builder.Ignore(c => c.TotalQuantity);
            //Relation one to one between customer and cart
            builder.HasOne(c => c.Customer)
                   .WithOne(c => c.Cart)
                   .HasForeignKey<Cart>(c => c.CustomerId);
        }
    }
}
