using Domain.Entities.Other;
using Domain.Exceptions;
using Domain.External;
using Persistence.OtherConfiguration;
using System.Net;
using System.Net.Mail;

namespace Persistence.External
{
    public class MailingRepository : IMailingRepository
    {
        private readonly MailConfiguration _mailConfiguration;

        public MailingRepository(MailConfiguration mailConfiguration) => 
            _mailConfiguration = mailConfiguration;        
        private void InitiateMail(MailData emailData, string fileBodyPath)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(_mailConfiguration.SenderEmail);
                mailMessage.To.Add(new MailAddress(emailData.To));
                mailMessage.Subject = emailData.Subject;

                using (StreamReader reader = File.OpenText(fileBodyPath))
                {
                    mailMessage.Body = reader.ReadToEnd();
                }

                mailMessage.Body = mailMessage.Body
                    .Replace(_mailConfiguration.Key, emailData.Body);


                mailMessage.IsBodyHtml = true;
                using (SmtpClient client = new SmtpClient(_mailConfiguration.Server, _mailConfiguration.Port))
                {
                    client.Credentials = new NetworkCredential(_mailConfiguration.SenderEmail, _mailConfiguration.Password);
                    client.EnableSsl = true;
                    client.Send(mailMessage);
                }
            }
        }
        public void SendEmailConfirmation(MailData emailData, string fileBodyPath)
        {
            {
                try
                {
                    string encodedEmail = WebUtility.UrlEncode(emailData.To);

                    if (!(emailData.Body.StartsWith("http")
                        || emailData.Body.StartsWith("https")))
                            throw new NotAllowedException("Not Vailid URL");
                    
                    if (emailData.Body.EndsWith("?"))
                        emailData.Body += $"email={encodedEmail}";
                    else
                        throw new NotAllowedException("Not Vailid URL for Rediriction");

                    InitiateMail(emailData, fileBodyPath);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void SendEmailReset(MailData emailData, string fileBodyPath)
        {
            {
                try
                {
                    InitiateMail(emailData, fileBodyPath);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
