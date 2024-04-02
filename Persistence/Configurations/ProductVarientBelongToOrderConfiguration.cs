using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProductVarientBelongToOrderConfiguration : IEntityTypeConfiguration<ProductVarientBelongToOrder>
    {
        public void Configure(EntityTypeBuilder<ProductVarientBelongToOrder> builder)
        {
           builder.HasKey(e => new {e.OrderId, e.ProductId, e.SizeId, e.ColorId });
           
            builder.Property(po => po.Id)
                .ValueGeneratedOnAddOrUpdate();
            builder.HasIndex(po => po.Id)
                   .IsUnique();

            builder.HasOne(po => po.Order)
                .WithMany(o => o.ProductBelongToOrders)
                .HasForeignKey(po => po.OrderId);

            builder.HasOne(po => po.ProductVarient)
               .WithMany(pv => pv.ProductBelongToOrders)
               .HasForeignKey(po => new { po.ProductId, po.SizeId, po.ColorId });
        }
    }
}
