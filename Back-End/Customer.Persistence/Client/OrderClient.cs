using Customer.Domain.Client;
using System.Net.Http.Json;

namespace Customer.Persistence.Client
{
    public class OrderClient : IOrderClient
    {
        private readonly HttpClient _httpClient;
        
        public OrderClient(HttpClient httpClient) =>
            _httpClient = httpClient;
       
        public Task<List<object>> GetOrders(int customerId)
        {
            var orderList = _httpClient.GetFromJsonAsync<List<object>>($"?Id={customerId}");

            if (orderList is null)
                throw new Exception("No Orders found");

            return orderList!;
        }
    }
}
