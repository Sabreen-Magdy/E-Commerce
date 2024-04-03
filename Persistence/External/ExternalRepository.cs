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
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private IAuthenticationRepository _loginRepository;
        private IMailingRepository _mailingRepository;
        private IPaymentRepository _paymentRepository;

        private readonly IConfiguration _configuration;

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

        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (_paymentRepository == null)
                {
                    PaymentConfiguration paymentConfiguration = new PaymentConfiguration();

                    _configuration.GetRequiredSection("Payment").Bind(paymentConfiguration);
                    _paymentRepository = new PaymentRepository(paymentConfiguration);
                }
                return _paymentRepository;
            }
        }
    }
}
