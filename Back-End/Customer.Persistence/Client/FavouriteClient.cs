using Customer.Domain.Client;
using System.Net.Http.Json;

namespace Customer.Persistence.Client;

public class FavouriteClient : IFavouriteClient
{
    private readonly HttpClient _httpClient;
   
    public FavouriteClient(HttpClient httpClient) => _httpClient = httpClient;
   
    public Task<List<object>> GetFavourites(int customerId)
    {
       var favoriteList = _httpClient.GetFromJsonAsync<List<object>>($"?Id={customerId}");
        
        if (favoriteList is null)
            throw new Exception("No Favourites found");

        return favoriteList!;
    }
}
