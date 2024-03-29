using Contract;
using Contract.Favorite;

namespace Services.Abstraction.DataServices;

public interface ICustomerService
{
    int GetNumberCustomers();
    List<CustomerDto> GetAll();
  
    CustomerDto? Get(int id);
    List<CustomerDto> Get(string name);

    void Add(CustomerAddDto customer);

    void Update(int id,CustomerAddDto customer);

    void Delete(int id);
    List<CustomerReviewDto> GetReviews(int customerId);
    List<FavoriteDto> GetFavourites(int customerId);
    List<OrderDto> GetOrders(int customerId);
    List<CartDto> GetCart(int customerId);

    void AddReview(int customerId, int productId, string comment, int rate);
    void UpdateReview(int id, string comment, int rate);
    void UpdateReview(int customerId, int productId, string comment, int rate); 
    void DeleteReview(int id);
    void DeleteReview(int customerId, int productId);
}
