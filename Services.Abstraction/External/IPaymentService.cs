using Braintree;
using Contract;
using Domain.Entities;
using Domain.Entities.Other;

namespace Services.Abstraction.External
{
    public interface IPaymentService
    {
        IBraintreeGateway CreateGetWay();
        IBraintreeGateway GetGetWay();
        Payment CreateTransaction(PaymentDto payment);
        string RefundTransaction(string transactionId);
    }
}
