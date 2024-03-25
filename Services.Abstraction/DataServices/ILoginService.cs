using Domain.Repositories;

namespace Services.Abstraction.DataServices
{
    public interface ILoginService
    {
        string GenerateJSONWebToken(User user);
        User? Login(string email, string password);
    }
}
