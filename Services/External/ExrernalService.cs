using Domain.External;
using Microsoft.Extensions.Options;
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
        private readonly IPaymentService _paymentService;

        public ExrernalService( 
            IExternalRepository repository, IAdminService adminService)
        {
            _loginService = new AuthenticationService(repository, adminService);
            _emailService = new EmailService(repository);
            _paymentService = new PaymentService(repository);
        }

        public IAuthenticationService AuthenticationService => _loginService;

        public IEmailService EmailService => _emailService;

        public IPaymentService PaymentService => _paymentService;
    }
}
