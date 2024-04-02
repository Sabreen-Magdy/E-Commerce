using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Context
{
    public static class InsertData
    {

        public static List<IdentityRole> AddRole() =>
            new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = UserRole.Saller.ToString(),
                    NormalizedName = UserRole.Saller.ToString().ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = UserRole.Customer.ToString(),
                    NormalizedName = UserRole.Customer.ToString().ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
            };
    }
}
