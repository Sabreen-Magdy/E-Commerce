
namespace Customer.Domain.Client;

public interface IFavouriteClient
{
    Task<List<object>> GetFavourites(int customerId);
}
