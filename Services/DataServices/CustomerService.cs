using Mapster;
using Services.Abstraction.DataServices;
using Contract.Customer;
using Domain.Enums;
using Domain.Exceptions;
using Contract.OrderItem;
using Contract.Order;
using Contract.Cart;
using Contract.ClientDto;
using Domain.Repositories;

namespace Services.DataServices;

public class CustomerService: ICustomerService
{
    private readonly ICustomerRepository _repository;
  
    public CustomerService(ICustomerRepository repository) 
        => _repository = repository;
    
    public List<CustomerDto>  GetAll() => 
        _repository.GetAll().Adapt<List<CustomerDto>>();
    
    public CustomerDto? Get(int id)
    {
        var customer = _repository.Get(id);
        return customer.Adapt<CustomerDto>();
    }
    public List<CustomerDto> Get(string name)
    {
        var customers = _repository.Get(name);
        return customers.Adapt<List<CustomerDto>>();
    }

    public void Add(CustomerAddDto customer)
    {
        _repository.Add(customer.Adapt< Domain.Entities.Customer>());

        _repository.SaveChanges();
    }

    public void Add(string name, string image, string phono, string email, string passwor)
    {
        _repository.Add(new Domain.Entities.Customer
        {
            Id = 0,
            Name = name,
            Image = image,
            Phone = phono,
            Email = email,
            Password = passwor
        });

        _repository.SaveChanges();
    }

    public void Update(CustomerAddDto customer)
    {
        _repository.Update(customer.Adapt<Domain.Entities.Customer>());

        _repository.SaveChanges();
    }

    private Domain.Entities.Customer updateCustomer(Domain.Entities.Customer customer, 
        Dictionary<CustomerProperties, string> newValues)
    {
        foreach (var item in newValues)
        {
            switch (item.Key)
            {
                case CustomerProperties.Name:
                    customer.Name = item.Value;
                    break;


                case CustomerProperties.Image:
                    customer.Image = item.Value;
                    break;
                case CustomerProperties.Passwor:
                    customer.Password = item.Value;
                    break;

                default:
                    throw new PropertyException(item.Key.ToString());
            }
        }
        return customer;
    }
    public void Update(int id, Dictionary<CustomerProperties, string> newValues)
    {
        var customer = _repository.Get(id);
        if (customer is null)
            throw new NotFoundException();
        else
        {
            _repository.Update(updateCustomer(customer, newValues));
            _repository.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var customer = _repository.Get(id);
        if (customer is null)
            throw new NotFoundException();
        else
        {
            _repository.Delete(customer);
            _repository.SaveChanges();
        }
    }

    public List<ItemDto> GetFavourites(int customerId) => null!;
        //_client.FavouriteClient
        //.GetFavourites(customerId).Adapt<List<ItemDto>>(); 

    public List<OrderDto> GetOrders(int customerId) =>  null!;
    //_client.OrderClient
    //.GetOrders(customerId).Adapt<List<OrderDto>>();

    public List<CartDto> GetCart(int customerId) => null!;
    //_client.CartClient
    //.GetCarts(customerId).Adapt<List<CartDto>>();

    public List<ReviewDto> GetReviews(int customerId) => null!;
    //_client.ReviewClient
    //    .GetReviews(customerId).Adapt<List<ReviewDto>>();
}
