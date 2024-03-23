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
        builder.Property(p => p.Code)
            .HasConversion(c => c.ToArgb(),
                            c => System.Drawing.Color.FromArgb(c));

        #endregion
    }
}
