using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Color> builder)
    {
        // Primary Key
        builder.HasKey(e => e.Id);

        #region Properties Constrains

        builder.Property(p => p.Name)
            .HasMaxLength(50);

        builder.HasIndex(b => b.Code)
            .IsUnique();

        #endregion
    }
}
