
using Customer.Domain.Client;

namespace Customer.Persistence.Client;

public class ClientAdmin : IClientAdmin
{
    private readonly HttpClient _httpClient;

    public ClientAdmin(HttpClient httpClient) =>
        _httpClient = httpClient;

    public IFavouriteClient FavouriteClient => new FavouriteClient(_httpClient);
    public IOrderClient OrderClient => new OrderClient(_httpClient);

    public ICartClient CartClient =>  new CartClient(_httpClient);
}
