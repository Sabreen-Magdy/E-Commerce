using Domain.Repositories;
using Services.Abstraction.DataServices;

namespace Persistence.Authentication
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public User? Login(string email, string password) =>
            _loginRepository.Login(email, password);
      
        public string GenerateJSONWebToken(User user) =>
            _loginRepository.GenerateJSONWebToken(user);
       
    }
}
