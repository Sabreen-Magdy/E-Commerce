using Domain.Entities;
using Domain.Entities.Other;

namespace Domain.External;
public interface IAuthenticationRepository
{
    Task<User> Login(string email, string password);

    //Task<string> GenerateJSONWebToken(User user);

    Task Remove(string id);
    Task<User> Register(Customer customer, string password);
    Task ChangePassword(string userId, string oldPassword, string newPassword);
    Task RestPassword(string otp, string token, string userId, string newPassword);
    Task<string> RestPassword(string email, string otp);
}
