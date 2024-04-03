using Microsoft.AspNetCore.Identity;

namespace Persistence.Context
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public string? OTP { get; set; }
    }
}
