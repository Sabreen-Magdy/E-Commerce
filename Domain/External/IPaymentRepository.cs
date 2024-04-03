namespace Domain.External
{
    public interface IPaymentRepository
    {
        Dictionary<string, string> GetConfigurations();
        //IBraintreeGateway CreateGetWay();
        //IBraintreeGateway GetGetWay();
        //Payment GreateTransaction(PaymentDto payment);
    }
}
