using Contract;
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

        public User? Login(LoginDto login) =>
            _loginRepository.Login(login.Email, login.Password);
      
        public string GenerateJSONWebToken(User user) =>
            _loginRepository.GenerateJSONWebToken(user);
       
    }
}
