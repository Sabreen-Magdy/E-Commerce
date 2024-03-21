namespace Domain.Repositories;

public interface ILoginRepository 
{
    bool Login(string username, string password);
}
