using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SallerConfigurations : IEntityTypeConfiguration<Saller>
{
    void IEntityTypeConfiguration<Saller>.Configure
        (EntityTypeBuilder<Saller> builder)
    {
        builder.Property(p => p.NId)
            .HasMaxLength(14)
            .IsRequired();
        builder.Property(p => p.Name)
            .HasMaxLength(25)
            .IsRequired();
        builder.Property(p => p.Password)
            .HasDefaultValue("m@S*n!S#")
            .HasMaxLength(20);

        builder.HasIndex(c => c.Email)
            .IsUnique();
        builder.HasIndex(p => p.NId)
            .IsUnique();

        // Constraints
        builder.ToTable(b => b
            .HasCheckConstraint("EmailValidation",
                "[Email] like '%[a-zA-Z0-9.]@__%.__%' and [Email] not like '%[-+/*]%'"));
        builder.ToTable(b => b
            .HasCheckConstraint("NidValidation", "len([NId]) = 14 and [NId] not like '%[a-zA-Z.+/*_]%'"));
    }
}
