using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Persistence.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Domain.Entities.Customer>
{
    void IEntityTypeConfiguration<Domain.Entities.Customer>.Configure
        (EntityTypeBuilder<Domain.Entities.Customer> builder)
    {
        // Primary Key
        builder.HasKey(e => e.Id);
        
        // Unique Property
        builder.HasIndex(e => e.Email)
               .IsUnique();

        #region Properties Constrains

        builder.Property(c => c.Name)
           .IsRequired()
           .HasMaxLength(80);

        builder.Property(c => c.Password)
          .IsRequired()
          .HasDefaultValue("1234567");

        #endregion

        #region Other Constraints
        
        builder.ToTable(b =>
            b.HasCheckConstraint("ImageValidation",
           "[Image] like '%.png'"));

        builder.ToTable(b => b
            .HasCheckConstraint("EmailValidation",
                "[Email] like '%[a-zA-Z0-9.]@__%.__%' and [Email] not like '%[-+/*]%'"));

        builder.ToTable(b =>
            b.HasCheckConstraint("PhoneValidation",
                "len([Phone]) = 11 and [Phone] not like '%[a-zA-Z]%'"));

        builder.ToTable(b =>
           b.HasCheckConstraint("PasswordValidation",
               "len([Password]) >= 6"));

        #endregion
    }
}
