using Domain.Entities;
using Domain.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BasketRepository(ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public void DeleteBasket(string basketId)
        {
            var basket = _dbContext.basketCustomers.Find(basketId);
            _dbContext.basketCustomers.Remove(basket);
            _dbContext.SaveChanges();
        }

        public BasketCustomer GetBasket(string basketId)
        {
            return _dbContext.basketCustomers.FirstOrDefault(b => b.Id==basketId);
        }

        public void UpdateBasket(BasketCustomer basketCustomer)
        {
            _dbContext.basketCustomers.Update(basketCustomer);
            _dbContext.SaveChanges();
        }
    }
}
