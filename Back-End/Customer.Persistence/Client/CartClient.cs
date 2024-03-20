using Customer.Domain.Client;
using System.Net.Http.Json;

namespace Customer.Persistence.Client
{
    public class CartClient : ICartClient
    {
        private HttpClient _httpClient;

        public CartClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public Task<List<object>> GetCarts(int customerId)
        {
            var cartList = _httpClient.GetFromJsonAsync<List<object>>($"/?id={customerId}");

            if (cartList is null)
                throw new Exception("No Caarts found");

            return cartList!;
        }
    }
}