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
   // List<CustomerDto> BestBuyers(int len); 

    CustomerDto? Get(int id);
    List<CustomerDto> Get(string name);
   
    void Add(CustomerAddDto customer);
    void Add(string name, string image, string phono,
             string email, string passwor);

    void Update(CustomerAddDto customer);
    void Update(int id, Dictionary<CustomerProperties, string> newValues);

    void Delete(int id);


    List<ReviewDto> GetReviews(int customerId);
    List<ItemDto> GetFavourites(int customerId);
    List<OrderDto> GetOrders(int customerId);
    List<CartDto> GetCart(int customerId);
}
