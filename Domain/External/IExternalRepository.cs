namespace Domain.External
{
    public interface IExternalRepository
    {
        IAuthenticationRepository AuthenticationRepository { get; }
        IMailingRepository MailRepository { get; }
    }
}
