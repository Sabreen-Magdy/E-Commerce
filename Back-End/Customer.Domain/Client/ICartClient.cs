

namespace Customer.Domain.Client;

public interface ICartClient
{
    Task<List<object>> GetCarts(int customerId);
}
