using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.UseTptMappingStrategy();

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
}
