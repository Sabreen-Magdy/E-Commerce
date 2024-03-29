using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CartRepository : ICardRepositry
    {
        private readonly ApplicationDbContext _dbContext;

        public CartRepository(ApplicationDbContext dbContext) =>
           _dbContext = dbContext;

        public void Add(CartItem entity) =>
            _dbContext.cartItems.Add(entity);
       
        public void Delete(CartItem entity)
        {
            _dbContext.cartItems.Remove(entity);
         
        }

        public CartItem? Get(int id)
        {
            return GetAll().Find(c => c.Id == id);
        }

        public List<CartItem> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetAll() =>
            _dbContext.cartItems
            .Include(ic => ic.ProductVarient)
                .ThenInclude(pv => pv.ColoredProduct).ThenInclude(pv => pv.Product)
             .Include(ic => ic.ProductVarient)
                .ThenInclude(pv => pv.ColoredProduct).ThenInclude(pv => pv.Color)
             .Include(ic => ic.ProductVarient)
                .ThenInclude(pv => pv.Size)
            .Include(ic => ic.Customer).ToList();

        public List<CartItem> GetByCustomerId(int customerId)
        {
            return GetAll().Where(c => c.CustomerId == customerId).ToList();
        }
        public void Update(CartItem entity)
        {
            _dbContext.cartItems.Update(entity);
        }
        public CartItem? GetItem(int customerId, int productVarientId)
        {
            var cart = GetByCustomerId(customerId);
            if (cart == null) throw new NotFoundException("Cart");

            return cart.SingleOrDefault(pv => pv.ProductVarient.Id == productVarientId);
        }

        public void AddRange(List<CartItem> items)
        {
            _dbContext.cartItems.AddRange(items);
        }
    }
}
