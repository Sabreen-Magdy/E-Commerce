using Domain.External;
using Persistence.Authentication;
using Services.Abstraction;
using Services.Abstraction.External;
using Services.Authentication;
namespace Services.External
{
    public class ExrernalService : IExrernalService
    {
        private readonly IAuthenticationService _loginService;
        private readonly IEmailService _emailService;

        public ExrernalService(IExternalRepository repository, IAdminService adminService)
        {
            _loginService = new AuthenticationService(repository, adminService);
            _emailService = new EmailService(repository);
        }

        public IAuthenticationService AuthenticationService => _loginService;

        public IEmailService EmailService => _emailService;
    }
}
