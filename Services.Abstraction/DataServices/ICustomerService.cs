using Contract.Cart;
using Contract.ClientDto;
using Contract.Customer;
using Contract.Order;
using Contract.OrderItem;
using Domain.Enums;

namespace Services.Abstraction.DataServices;

public interface ICustomerService
{
    List<CustomerDto> GetAll();
  
    CustomerDto? Get(int id);
    List<CustomerDto> Get(string name);

    void Add(CustomerAddDto customer);

    void Update(int id, Dictionary<Properties, string> newValues);

    void Delete(int id);


    List<CustomerReviewDto> GetReviews(int customerId);
    List<ItemDto> GetFavourites(int customerId);
    List<OrderDto> GetOrders(int customerId);
    List<CartDto> GetCart(int customerId);
}
