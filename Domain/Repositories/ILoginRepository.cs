using Domain.Entities;

namespace Domain.Repositories;

public interface ILoginRepository 
{
    User? Login(string email, string password);
    
    string GenerateJSONWebToken(User user);
}
