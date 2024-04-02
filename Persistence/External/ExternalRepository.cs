using Domain.External;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Persistence.Context;
using Persistence.ExternalConfiguration;
using Persistence.OtherConfiguration;


namespace Persistence.External
{
    public class ExternalRepository : IExternalRepository
    {
        private IAuthenticationRepository _loginRepository;
        private IMailingRepository _mailingRepository;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationIdentityUser> _userManager;

        public ExternalRepository(IConfiguration configuration,
            UserManager<ApplicationIdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public IAuthenticationRepository AuthenticationRepository
        {
            get
            {
                if (_loginRepository == null)
                {
                    AuthenticationConfiguration loginConfiguration = new AuthenticationConfiguration();

                    _configuration.GetRequiredSection("Jwt").Bind(loginConfiguration);
                    _loginRepository = new AuthenticationRepository(loginConfiguration, _userManager);
                }
                return _loginRepository;
            }
        }

        public IMailingRepository MailRepository
        {
            get
            {
                if (_mailingRepository == null)
                {
                    MailConfiguration loginConfiguration = new MailConfiguration();

                    _configuration.GetRequiredSection("MailSettings").Bind(loginConfiguration);
                    _mailingRepository = new MailingRepository(loginConfiguration);
                }
                return _mailingRepository;
            }
        }
    }
}
