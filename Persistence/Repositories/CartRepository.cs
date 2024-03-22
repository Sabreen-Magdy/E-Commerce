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
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Cart cart)
        {
            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var cart = _dbContext.Carts.Find(id);
            if (cart != null)
            {
                _dbContext.Carts.Remove(cart);
                _dbContext.SaveChanges();
            }
        }

        public Cart? GetByCustomerId(int customerId)
        {
            return _dbContext.Carts.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public Cart? GetById(int id)
        {
            return _dbContext.Carts.Find(id);

        }

        public void Update(Cart cart)
        {
            _dbContext.Carts.Update(cart);
            _dbContext.SaveChanges();
        }
    }
}
