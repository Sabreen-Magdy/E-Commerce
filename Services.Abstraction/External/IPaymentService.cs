using Braintree;
using Contract;
using Domain.Entities.Other;

namespace Services.Abstraction.External
{
    public interface IPaymentService
    {
        IBraintreeGateway CreateGetWay();
        IBraintreeGateway GetGetWay();
        Payment GreateTransaction(PaymentDto payment);
        Payment RefundTransaction(string transactionId);
    }
}
