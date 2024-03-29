using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        // Primary Key
        builder.HasKey(e => e.Id);

        // Properties Constrains
        builder.Property(p => p.Name)
            .HasMaxLength(10);

        builder.HasIndex(b => b.Name)
            .IsUnique();
    }
}
