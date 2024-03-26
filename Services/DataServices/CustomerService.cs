using Contract;
using Contract.Favorite;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.Extenstions;

namespace Services.DataServices;

public class CustomerService : ICustomerService
{
    private readonly IAdminRepository _repository;

    public CustomerService(IAdminRepository repository)
        => _repository = repository;

    public List<CustomerDto> GetAll() =>
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
        _repository.CustomerRepository.Add(new Customer
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

    private Customer UpdateCustomer(Customer customer,
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
                case Properties.Password:
                    customer.Password = item.Value;
                    break;

                default:
                    throw new PropertyException(item.Key.ToString());
            }
        }
        return customer;
    }
    public void Update(CustomerDto customerDto)
    {
       // var customer = _repository.CustomerRepository.Get(id);
        if (customerDto is null)
            throw new NotFoundException("Customer");
        else
        {
            _repository.CustomerRepository.Update(customerDto.ToCustomerEntity());
            _repository.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var customer = _repository.CustomerRepository.Get(id);
        if (customer is null)
            throw new NotFoundException("Customer");
        else
        {
            _repository.CustomerRepository.Delete(customer);
            _repository.SaveChanges();
        }
    }

    public List<FavoriteDto> GetFavourites(int customerId) =>
         _repository.FavouriteRepository
                    .GetByCustomer(customerId)
                    .ToFavoriteDto();


    public List<OrderDto> GetOrders(int customerId) =>
        _repository.OrderReposatory
                    .GetByCustomer(customerId)
                    .ToOrderDto();

    public List<CartDto> GetCart(int customerId) => null!;
    //_repository.OrderReposatory
    //            .GetByCustomer(customerId)
    //            .ToOrderDto();

    public List<CustomerReviewDto> GetReviews(int customerId) => null!;
    //_repository.ReviewRepository
    //           .GetByCustomer(customerId)
    //           .ToCustomerReviewDto();

    public void AddReview(int customerId, int productId, string comment, int rate)
    {
        _repository.ReviewRepository.Add(
            new()
            {
                CustomerId = customerId,
                ProductId = productId,
                Comment = comment,
                Rate = rate
            });

        int affectedRows = _repository.SaveChanges();
        if (affectedRows != 0)
        {
            _repository.ProductRepository.AddReview(productId, rate);
            _repository.SaveChanges();
        }
    }

    private void DeleteRiview(Review? review)
    {
        if (review == null)
            throw new NotFoundException("Review");

        _repository.ReviewRepository.Delete(review);
        int affectedRows = _repository.SaveChanges();
        if (affectedRows != 0)
        {
            _repository.ProductRepository
                .DeleteReview(review.ProductId, review.Rate);
            _repository.SaveChanges();
        }
    }
    private void UpdateRiview(Review? review)
    {
        if (review == null)
            throw new NotFoundException("Review");
        _repository.ReviewRepository.Update(review);
        _repository.SaveChanges();
    }

    public void UpdateReview(int id, string comment, int rate) =>
        UpdateRiview(_repository.ReviewRepository.Get(id));
    public void UpdateReview(int customerId, int productId, string comment, int rate) =>
        UpdateRiview(_repository.ReviewRepository
            .GetByCustomerProduct(customerId, productId));

    public void DeleteReview(int id) =>
        DeleteRiview(_repository.ReviewRepository.Get(id));
    public void DeleteReview(int customerId, int productId) =>
        DeleteRiview(_repository.ReviewRepository
            .GetByCustomerProduct(customerId, productId));

}
