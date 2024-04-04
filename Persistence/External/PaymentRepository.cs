using Domain.External;

namespace Persistence.External
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentConfiguration _configuration;

        public PaymentRepository(PaymentConfiguration configuration) =>
            _configuration = configuration;

        public Dictionary<string, string> GetConfigurations()
        {
            var dict = new Dictionary<string, string>
            {
                { "PrivateKey", _configuration.PrivateKey },
                {"PublicKey", _configuration.PublicKey },
                {"MerchantId", _configuration.MerchantId},
                { "Environment", _configuration.Environment },
            };
            return dict;
        }
    }
}