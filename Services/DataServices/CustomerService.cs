using Mapster;
using Contract.Customer;
using Domain.Enums;
using Domain.Exceptions;
using Contract.OrderItem;
using Contract.Order;
using Contract.Cart;
using Contract.ClientDto;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.DataServices.Extenstions;

namespace Services.DataServices;

public class CustomerService: ICustomerService
{
    private readonly IAdminRepository _repository;

    public CustomerService(IAdminRepository repository) 
        => _repository = repository;
    
    public List<CustomerDto>  GetAll() => 
        _repository.CustomerRepository.GetAll().ToCustomerDto();
    
    public CustomerDto? Get(int id)
    {
        var customer = _repository.CustomerRepository.Get(id);
        return customer!.ToCustomerDto();
    }
    public List<CustomerDto> Get(string name)
    {
        var customers = _repository.CustomerRepository.Get(name);
        return customers.ToCustomerDto();
    }

    public void Add(CustomerAddDto customer)
    {
        _repository.CustomerRepository.Add(customer.ToCustomerEntity());

        _repository.SaveChanges();
    }

    public void Add(string name, string image, string phono, string email, string passwor)
    {
        _repository.CustomerRepository.Add(new Domain.Entities.Customer
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
        _repository.CustomerRepository.Update(customer.ToCustomerEntity());

        _repository.SaveChanges();
    }

    private Domain.Entities.Customer updateCustomer(Domain.Entities.Customer customer, 
        Dictionary<Properties, string> newValues)
    {
        foreach (var item in newValues)
        {
            switch (item.Key)
            {
                case Properties.Name:
                    customer.Name = item.Value;
                    break;


                case Properties.Image:
                    customer.Image = item.Value;
                    break;
                case Properties.Passwor:
                    customer.Password = item.Value;
                    break;

                default:
                    throw new PropertyException(item.Key.ToString());
            }
        }
        return customer;
    }
    public void Update(int id, Dictionary<Properties, string> newValues)
    {
        var customer = _repository.CustomerRepository.Get(id);
        if (customer is null)
            throw new NotFoundException();
        else
        {
            _repository.CustomerRepository.Update(updateCustomer(customer, newValues));
            _repository.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var customer = _repository.CustomerRepository.Get(id);
        if (customer is null)
            throw new NotFoundException();
        else
        {
            _repository.CustomerRepository.Delete(customer);
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

    public List<CustomerReviewDto> GetReviews(int customerId) => null!;
    //_client.ReviewClient
    //    .GetReviews(customerId).Adapt<List<ReviewDto>>();
}
