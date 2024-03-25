﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name)
                .IsUnique();

            builder.Property(c => c.Description)
                .HasMaxLength(255);
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
