using Braintree;
using Contract;
using Domain.Entities.Other;
using Domain.Exceptions;
using Services.Abstraction.External;

namespace Services.External
{
    public class PaymentConfiguration
    {
        public Braintree.Environment Environment { get; set; } = null!;
        public string MerchantId { get; set; } = null!;
        public string PublicKey { get; set; } = null!;
        public string PrivateKey { get; set; } = null!;
    }
    public class PaymentService(PaymentConfiguration configure) : IPaymentService
    {
        private readonly PaymentConfiguration _configure = configure;
        private IBraintreeGateway BraintreeGateway { get; set; }
       
        public IBraintreeGateway CreateGetWay() =>
                new BraintreeGateway()
                {
                    Environment = _configure.Environment,
                    MerchantId = _configure.MerchantId,
                    PublicKey = _configure.PublicKey,
                    PrivateKey = _configure.PrivateKey,            
                };

        public IBraintreeGateway GetGetWay()
        {
            if (BraintreeGateway == null)
                BraintreeGateway = CreateGetWay();
            return BraintreeGateway;
        }

        public Payment GreateTransaction(PaymentDto payment)
        {
            var getway = GetGetWay();
            var transaction = new TransactionRequest
            {
                Amount = payment.Amount,
                PaymentMethodNonce = payment.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                },
                CurrencyIsoCode = payment.CurrencyIsoCode,
            };

            var results = getway.Transaction.Sale(transaction);
            if (results.IsSuccess())
                return new()
                {
                    TransactionId = results.Transaction.Id,
                    Amount = results.Transaction.Amount,
                    PaymentInstrumentSubtype = results.Transaction.PaymentInstrumentType.GetDescription(),
                    CreatedAt = results.Transaction.CreatedAt,
                    CurrencyIsoCode = results.Transaction.CurrencyIsoCode,
                    Nonce = payment.Nonce,


                };
            else
                throw new PaymentFailedException(results.Message);
        }      
    }
}
