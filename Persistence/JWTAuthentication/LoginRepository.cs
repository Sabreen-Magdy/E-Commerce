using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Persistence.JWTAuthentication
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;
        public LoginRepository(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public User? Login(string email, string password)
        {
            var userCostomer = _dbContext.Customers
                            .FirstOrDefault(u => u.Password.Equals(email)
                            && u.Password.Equals(password));
            if (userCostomer == null)
            {
                var userSaller = _dbContext.Sallers
                            .FirstOrDefault(u => u.Password.Equals(email)
                            && u.Password.Equals(password));

                if (userSaller != null)
                    return new()
                    {
                        Id = userSaller.Id,
                        Role = userSaller.Role
                    };
                else return null;
            }
            else return new()
            {
                Id = userCostomer.Id,
                Role = userCostomer.Role
            };

        }
      
        public string GenerateJSONWebToken(User user)
        {
            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            if (key is null || issuer is null || audience is null)
                throw new ArgumentNullException("JWT Paramters Not Found");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                 new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                 new Claim("Role", user.ToString())
            };

            var token = new JwtSecurityToken(issuer, audience, claims,
               // expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}
