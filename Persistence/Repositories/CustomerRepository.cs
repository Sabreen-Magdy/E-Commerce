using Domain.Entities;
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context) =>
        _context = context;

    public int GetNumberCustomers() => _context.Customers.Count();
    public List<Customer> GetAll() =>
        _context.Customers.ToList();

    public void Add(Customer customer) =>
      _context.Customers.Add(customer);


    public void Delete(Customer customer) =>
      _context.Customers.Remove(customer);

    public Customer? Get(int id) =>
      _context.Customers.Find(id);

    public List<Customer> Get(string name) =>
      _context.Customers.Where(c => c.Name == name)
                    .Select(c => c).ToList();

    public void Update(Customer customer) =>
      _context.Customers.Update(customer);

    public void Updatecust(int id, Customer customer)
    {
            var existingCustomer = _context.Customers.Find(id);

            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name; 
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Password = customer.Password;
            }
            else
            {
                throw new Exception("Customer not found");
            }
        

    }
}