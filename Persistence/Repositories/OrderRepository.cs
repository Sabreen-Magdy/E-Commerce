using Contract;
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
        
        public double GetProfit(int state) =>
             _context.Orders.Where(o=> o.State == state)
                .Sum(o => o.TotalCost);
       
        public int GetNumberOrders(int state) => 
            _context.Orders.Count(o => o.State == state);
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
            return GetAll().FirstOrDefault(o => o.Id == id);
        }

        public List<Order> Get(string name)
        {
            return GetAll().Where(o => o.Customer.Name == name).Select(O=>O).ToList() ;
        }

        public List<Order> GetAll()
        {
            return  _context.Orders
                .Include(o => o.Customer)   
                .Include(o => o.ProductBelongToOrders)
                    .ThenInclude(o => o.ProductVarient)
                        .ThenInclude(pv => pv.ColoredProduct)
                            .ThenInclude(cp => cp.Color)
                 .Include(o => o.ProductBelongToOrders)
                    .ThenInclude(o => o.ProductVarient)
                        .ThenInclude(pv => pv.ColoredProduct)
                            .ThenInclude(cp => cp.Product)
                 .Include(o => o.ProductBelongToOrders)
                    .ThenInclude(o => o.ProductVarient)
                        .ThenInclude(pv => pv.Size)
                   .ToList();
        }

        public List<Order> GetByCustomer(int customerID)
        {
            return GetAll().Where(o=> o.CustomerId == customerID).ToList();
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
        }

        
        private IEnumerable<Order> FilterByMonth(int state) =>
            _context.Orders
            .Where(o => o.State == state
                     && o.ConfirmDate != null && o.ConfirmDate.Value.Year == DateTime.Now.Year
                     && o.ConfirmDate.Value.Month == DateTime.Now.Month
                     && o.ConfirmDate.Value.Day <= DateTime.Now.Day
                     && o.ConfirmDate.Value.Day > DateTime.Now.Day - 7);

        public List<KeyValuePair<int, double>> GetProfitByYear(int state) => _context.Orders
            .Where(o => o.State == state && 
                        o.ConfirmDate != null && o.ConfirmDate.Value.Year == DateTime.Now.Year)
            .GroupBy(ks => ks.ConfirmDate!.Value.Month)
            .Select(mo => new  KeyValuePair<int, double>(mo.Key,  mo.Sum(o=> o.TotalCost))).ToList();
            
        public List<KeyValuePair<int, double>> GetProfitByWeek(int state) =>
            FilterByMonth(state).GroupBy(ks => ks.ConfirmDate!.Value.Day)
            .Select(mo => new KeyValuePair<int, double>(mo.Key, mo.Sum(o => o.TotalCost))).ToList();

        public List<KeyValuePair<DayOfWeek, double>> GetProfitByWeekDay(int state) =>
           FilterByMonth(state).GroupBy(ks => ks.ConfirmDate!.Value.DayOfWeek)
           .Select(mo => new KeyValuePair<DayOfWeek, double>(mo.Key, mo.Sum(o => o.TotalCost))).ToList();

    }
}
