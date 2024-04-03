using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(o => o.OrderedDate)
            .HasDefaultValueSql("GetDate()");
        builder.Property(o => o.Comment)
            .HasDefaultValue("يُرجى الانتظار بينما يقوم البائع بمراجعة طلبك واتخاذ قرار بشأن قبوله أو رفض");
      
        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        builder.ToTable(b => b.HasCheckConstraint("StateValidation",
            "[State] >= 0 and [State] <= 3"));

        //builder.ToTable(b => b.HasCheckConstraint("OrderedDateValidation",
        //    $"{Unity.CheckDate(Properties.OrderedDate.ToString())} and {Unity.CheckDate(Properties.ConfirmDate.ToString(), Properties.OrderedDate.ToString())}"           
        //    ));
        //builder.ToTable(b => b.HasCheckConstraint("ConfirmDateValidation",
        //        $"{Unity.CheckDate(Properties.ConfirmDate.ToString())} and {Unity.CheckDate(Properties.ConfirmDate.ToString(), Properties.OrderedDate.ToString())}"
        //    ));
    }
}
