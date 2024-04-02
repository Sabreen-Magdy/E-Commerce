namespace Services.Abstraction.External
{
    public interface IExrernalService
    {
        public IAuthenticationService AuthenticationService { get; }
        public IEmailService EmailService { get; }
    }
}
