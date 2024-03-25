using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)=>
        _context = context;


    public List<Domain.Entities.Customer> GetAll() =>
        _context.Customers.ToList();

    public void Add(Domain.Entities.Customer customer) =>
      _context.Customers.Add(customer);
      

    public void Delete(Domain.Entities.Customer customer) =>
      _context.Customers.Remove(customer);

    public Domain.Entities.Customer? Get(int id) =>
      _context.Customers.Find(id);

    public List<Domain.Entities.Customer> Get(string name) =>
      _context.Customers.Where(c => c.Name == name)
                    .Select(c => c).ToList();

    public void Update(Domain.Entities.Customer customer) =>
      _context.Customers.Update(customer);

}
