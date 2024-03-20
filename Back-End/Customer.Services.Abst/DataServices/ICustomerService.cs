using Customer.Contract.ClientDto;
using Customer.Contract.Customer;
using Customer.Domain.Enums;

namespace Customer.Services.Abst.DataServices;

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


    List<ItemDto> GetFavourites(int customerId);
    List<OrderDto> GetOrders(int customerId);
    List<CartDto> GetCart(int customerId);
}
