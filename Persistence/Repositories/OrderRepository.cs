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
            return  _context.Orders.Include(o=>o.Customer).Include(o=>o.ProductBelongToOrders).ToList();
        }

        public List<Order> GetByCustomer(int customerID)
        {
            return _context.Orders.Where(o=> o.CustomerId == customerID).ToList();
        }

        //public List<Order> GetByProduct(int productID)
        //{
        //    return _context.Orders.Where(o => o. == customerID).ToList();
        //}

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
        }
    }
}
