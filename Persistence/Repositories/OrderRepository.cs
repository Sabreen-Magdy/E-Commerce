using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OrderRepository : IOrderReposatory
    {

        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) =>
            _context = context;

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
        }

        public Order? Get(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> Get(string name)
        {
            return _context.Orders.Where(o => o.Customer.Name == name).Select(O=>O).ToList() ;
        }

        public List<Order> GetAll()
        {
            return  _context.Orders.ToList();
        }

        public List<Order> GetByCustomer(int customerID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetByProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
        }
    }
}
