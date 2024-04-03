using Domain.Entities.Other;

namespace Services.Abstraction.External
{
    public interface IEmailService
    {
        void SendEmailConfirmation(MailData emailData, string fileBodyPath);
        void SendEmailReset(MailData emailData, string fileBodyPath);
    }
}
