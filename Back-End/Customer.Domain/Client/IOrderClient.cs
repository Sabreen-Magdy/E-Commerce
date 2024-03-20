namespace Customer.Domain.Client;

public interface IOrderClient
{
    Task<List<object>> GetOrders(int customerId);
}
