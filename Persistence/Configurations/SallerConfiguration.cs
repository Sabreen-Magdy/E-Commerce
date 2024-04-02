using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Context;

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
        //builder.Property(p => p.Password)
        //    .HasDefaultValue("m@S*n!S#")
        //    .HasMaxLength(20);

        builder.HasIndex(c => c.Email)
            .IsUnique();
        builder.HasIndex(p => p.NId)
            .IsUnique();

        builder.ToTable(b => b
            .HasCheckConstraint("NidValidation", "len([NId]) = 14 and [NId] not like '%[a-zA-Z.+/*_]%'"));

        Unity.ApplyEmailConstraint(builder);


        builder.HasOne(typeof(ApplicationIdentityUser)).WithMany()
            .HasForeignKey("UserId").OnDelete(DeleteBehavior.NoAction); //
    }
}
