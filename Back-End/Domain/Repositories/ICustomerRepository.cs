using Domain.Entities;

namespace Domain.Repositories;

public interface ICustomerRepository
{
    List<Customer> GetAll();
    Customer? Get(int id);
    List<Customer> Get(string name);
    void Add(Customer customer);
    void Update(Customer customer);
    void Delete(Customer customer);

    int SaveChanges();
}
