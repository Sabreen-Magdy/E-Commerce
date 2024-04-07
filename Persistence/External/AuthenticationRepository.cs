using Domain.Entities;
using Domain.Enums;
using Domain.Entities.Other;
using Domain.Exceptions;
using Domain.External;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence.ExternalConfiguration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Persistence.Context;

namespace Persistence.External
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AuthenticationConfiguration _configuration;
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        public AuthenticationRepository(AuthenticationConfiguration configuration,
            UserManager<ApplicationIdentityUser> userManager)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        private async Task<JwtSecurityToken> GenerateJSONWebToken(ApplicationIdentityUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            foreach (var role in userRoles)
                userClaims.Add(new("Role", role));

            if (_configuration.Key is null
                || _configuration.Issuer is null || _configuration.Audience is null)
                throw new ArgumentNullException("JWT Paramters Not Found");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            return new JwtSecurityToken(_configuration.Issuer, _configuration.Audience, claims,
                expires: DateTime.Now.AddDays(_configuration.AvailavleDays),
                signingCredentials: credentials);
        }


        public async Task<User> Login(string email, string password)
        {
           var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
                throw new UnauthorizedAccessException("Email or Password is Incorrect");

            var jwtToken = await GenerateJSONWebToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            return new User()
            {
                ExpiredDate = jwtToken.ValidTo,
                Role = roles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken)
            };
        }
      
       
        public async Task<User> Register(Customer customer, string password)
        {
            if (await _userManager.FindByEmailAsync(customer.Email) != null)
                throw new AlreadyExistException($"Customer with {customer.Email}");

            var user = new ApplicationIdentityUser
            {
                Email = customer.Email,
                UserName = customer.Email,
                PhoneNumber = customer.Phone
            };

            var res = await _userManager.CreateAsync(user, password);

            if (!res.Succeeded)
            {
                var mess = "";
                foreach (var error in res.Errors) mess += $"{error.Description},";
                throw new NotAllowedException(mess);
            }
            await _userManager.AddToRoleAsync(user, UserRole.Customer.ToString()); /********      here   *********/

            customer.UserId = user.Id;

            var jwtToken = await GenerateJSONWebToken(user);
            return new User()
            {
                ExpiredDate = jwtToken.ValidTo,
                Role = new List<string> { UserRole.Customer.ToString() },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken)
            };
        }

        public async Task Remove(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
                 await  _userManager.DeleteAsync(user);
        }

        public async Task ChangePassword(string userId, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new NotFoundException("User");

           var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!result.Succeeded) throw new UnauthorizedAccessException("Something Happened");
        }

        public async Task RestPassword(string otp, string token, string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new NotFoundException("User");

            if (user.OTP == otp)
            {
                user.OTP = null;
                await _userManager.UpdateAsync(user);

                await _userManager.ResetPasswordAsync(user, token, newPassword);
            }
            else
                throw new NotAllowedException("OTP Not Valid");

        }
        public async Task<string> RestPassword(string email, string otp)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new NotFoundException("User");

            user.OTP = otp;
            await _userManager.UpdateAsync(user);
           
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return token;    
        }

        public async Task<bool> CanRegister(string email) =>
            await _userManager.FindByEmailAsync(email) == null;
    }
}
