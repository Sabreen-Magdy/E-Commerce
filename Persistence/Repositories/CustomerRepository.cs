using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context) =>
        _context = context;

    public int GetNumberCustomers() => _context.Customers.Count();
    public List<Customer> GetAll() =>
        _context.Customers
        .Include(c => c.Orders)
            .ThenInclude(o => o.ProductBelongToOrders)
        .Include(c => c.Cart)
        .ToList();

    public void Add(Customer customer) =>
      _context.Customers.Add(customer);


    public void Delete(Customer customer) =>
      _context.Customers.Remove(customer);

    public Customer? Get(int id) =>
      GetAll().Find(c => c.Id == id);

    public List<Customer> Get(string name) =>
      GetAll().Where(c => c.Name == name)
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