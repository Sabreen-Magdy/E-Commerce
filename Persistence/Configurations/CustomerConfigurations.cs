using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    void IEntityTypeConfiguration<Customer>.Configure
        (EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.Address)
            .HasMaxLength(1000);

        // Other Constraints
        builder.ToTable(b =>
            b.HasCheckConstraint("ImageValidation",
           "[Image] like '%.png'"));
    }
}
