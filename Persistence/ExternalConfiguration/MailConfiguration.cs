namespace Persistence.OtherConfiguration
{
    public class MailConfiguration
    {
        public string Server { get; set; } = null!;
        public int Port { get; set; }
        //public string Value { get; set; } = null!;
        public string Key { get; set; } = null!;
        public string SenderEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
