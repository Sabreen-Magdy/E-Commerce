using Domain.Enums;

namespace Domain.Repositories;
public record User
{
    public int Id { get; set; }
    public UserRole Role { get; set; }
}
public interface ILoginRepository 
{
    User? Login(string email, string password);
    
    string GenerateJSONWebToken(User user);
}
