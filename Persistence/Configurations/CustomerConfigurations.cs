using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

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
        #region Relationship Constrains
        //Relation one to one between customer and cart
        builder.HasOne(c => c.Cart)
               .WithOne(c => c.Customer)
               .HasForeignKey<Cart>(c => c.CustomerId);

        //Relation one to one between customer and Favorite
        builder.HasOne(c => c.Favourite)
               .WithOne(f => f.Customer)
               .HasForeignKey<Favourite>(f => f.CustomerId);
        #endregion

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
