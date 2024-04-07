using Braintree;
using Contract;
using Domain.Entities;
using Domain.Entities.Other;
using Domain.Exceptions;
using Domain.External;
using Services.Abstraction;
using Services.Abstraction.External;

namespace Services.External
{
    public class PaymentService : IPaymentService
    {
        private readonly Dictionary<string, string> _confogurations;

        public PaymentService(IExternalRepository repository)
        {
            _confogurations = repository.PaymentRepository.GetConfigurations();
        }

        private IBraintreeGateway BraintreeGateway { get; set; }
       
        public IBraintreeGateway CreateGetWay() =>
                new BraintreeGateway()
                {
                    Environment = Braintree.Environment
                    .ParseEnvironment(_confogurations["Environment"]),
                    MerchantId = _confogurations["MerchantId"],
                    PublicKey = _confogurations["PublicKey"],
                    PrivateKey = _confogurations["PrivateKey"],            
                };

        public IBraintreeGateway GetGetWay()
        {
            if (BraintreeGateway == null)
                BraintreeGateway = CreateGetWay();
            return BraintreeGateway;
        }

        public Payment CreateTransaction(PaymentDto payment)
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
                    PayedTransactionId = results.Target.Id,
                    PayedAmount = results.Target.Amount,
                    TransactionDate = results.Target.CreatedAt,
                    CurrencyIsoCode = results.Target.CurrencyIsoCode,
                    Nonce = payment.Nonce,

                };
            else
                throw new PaymentFailedException(results.Message);
        }

        public string RefundTransaction(string transactionId)
        {
            var getway = GetGetWay();
            var results = getway.Transaction.Refund(transactionId);

            if (results.IsSuccess())

                return results.Target.Id;
            else
                throw new PaymentFailedException(results.Message);
        }
    }
}
