using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SallerConfigurations : IEntityTypeConfiguration<Saller>
{
    void IEntityTypeConfiguration<Saller>.Configure
        (EntityTypeBuilder<Saller> builder)
    {
    }
}
