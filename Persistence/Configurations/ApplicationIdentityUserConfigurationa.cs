using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Context;

namespace Persistence.Configurations
{
    internal class ApplicationIdentityUserConfigurationa 
        : IEntityTypeConfiguration<ApplicationIdentityUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationIdentityUser> builder)
        {
            builder.Property(u => u.OTP)
                .HasMaxLength(6);

            builder.ToTable(b => b.HasCheckConstraint(
                "OTPValidation", "len([OTP]) = 6"));


        }
    }
}
