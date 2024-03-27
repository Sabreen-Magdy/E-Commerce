using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class CartRepository : ICardRepositry
    {
        private readonly ApplicationDbContext _dbContext;

        public CartRepository(ApplicationDbContext dbContext) =>
           _dbContext = dbContext;

        public void Add(Cart cart)
        {
            _dbContext.Carts.Add(cart);
        }
        public void AddItem(CartItem item)
        {
            _dbContext.cartItems.Add(item);
        }
        
        public void DeletItem(CartItem item)
        {
            if (item != null)
                _dbContext.cartItems.Remove(item);
            else throw new NotFoundException("Cart Item");

        }

        public void Delete(Cart entity)
        {
            _dbContext.Carts.Remove(entity);
         
        }

        public Cart? Get(int id)
        {
            return GetAll().Find(c => c.Id == id);
        }

        public List<Cart> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetAll() =>
            _dbContext.Carts
            .Include(ic => ic.ProductVarients)
                .ThenInclude(pv => pv.ColoredProduct).ThenInclude(pv => pv.Product) //ProductVarient
            .Include(ic => ic.CartItems)
                .ThenInclude(ci => ci.ProductVarient)
                    .ThenInclude(ic => ic.ColoredProduct)
                        .ThenInclude(ci => ci.Product)

            .Include(ic => ic.Customer).ToList();

        public Cart? GetByCustomerId(int customerId)
        {
            return GetAll().FirstOrDefault(c => c.CustomerId == customerId);
        }
        public void Update(Cart cart)
        {
            _dbContext.Carts.Update(cart);
        }
        public CartItem? GetItem(int cartId,int productVarientId)
        {
            var cart = Get(cartId);
            if (cart == null)  throw new NotFoundException("Cart");
            
            return cart.CartItems.FirstOrDefault(ci => ci.ProductVarient.Id == productVarientId);
        }

        public void UpdateItem(CartItem item)
        {
            _dbContext.cartItems.Update(item);
        }
    }
}
