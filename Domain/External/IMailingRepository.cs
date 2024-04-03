using Domain.Entities.Other;

namespace Domain.External
{
    public interface IMailingRepository
    {
       public void SendEmailConfirmation(MailData emailData, string fileBodyPath);
       void SendEmailReset(MailData emailData, string fileBodyPath);
    }
}
