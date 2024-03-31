using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    void IEntityTypeConfiguration<Customer>.Configure
        (EntityTypeBuilder<Customer> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(25)
            .IsRequired();
        builder.Property(p => p.Address)
            .HasMaxLength(100);
        builder.Property(p => p.Password)
            .HasDefaultValue("m@S*n!S#")
            .HasMaxLength(20);

        builder.HasIndex(c => c.Email)
            .IsUnique();

        // Other Constraints
        builder.ToTable(b =>
            b.HasCheckConstraint("ImageValidation",
           "[Image] like '%.png'"));

        Unity.ApplyEmailConstraint(builder);
    }
}
