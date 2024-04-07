using Contract;
using Domain.Entities.Other;
namespace Services.Abstraction.External
{
    public interface IAuthenticationService
    {
        Task<User> Login(LoginDto login);

        Task<User> Register(CustomerAddDto customer);
        Task DeleteCustomer(int customerId);
        Task ChangePassword(ChangePasswordDto passwordDto);
        Task RestPassword(ForgetPasswordDto passwordDto);
        Task<OtpToken> RestPassword(string email);
        Task<bool> CanRegister(string email);
    }
}
