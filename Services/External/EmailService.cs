using Domain.Entities.Other;
using Domain.External;
using Services.Abstraction.External;


namespace Services.Authentication
{
    public class EmailService : IEmailService
    {
        private readonly IExternalRepository _repository;
        
        public EmailService(IExternalRepository repository)
        {
            _repository = repository;
        }
        public void SendEmailConfirmation(MailData emailData, string fileBodyPath) =>
            _repository.MailRepository.SendEmailConfirmation(emailData, fileBodyPath);


        public void SendEmailReset(MailData emailData, string fileBodyPath) =>
            _repository.MailRepository.SendEmailReset(emailData, fileBodyPath);
    }
}