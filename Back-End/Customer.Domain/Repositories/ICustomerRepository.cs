namespace Customer.Domain.Repositories;

public interface ICustomerRepository
{
    List<Entities.Customer> GetAll();
    Entities.Customer? Get(int id);
    List<Entities.Customer> Get(string name);
    void Add(Entities.Customer customer);
    void Update(Entities.Customer customer);
    void Delete(Entities.Customer customer);

    int SaveChanges();
}
