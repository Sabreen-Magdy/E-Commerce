using Domain.Entities;
using Domain.Repositories;
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
            _dbContext.SaveChanges();
        }
        public void AddItem(CartItem item)
        {
            _dbContext.cartItems.Add(item);
        }
        public void DeletItem(int cartId,int productId)
        {
            var item = _dbContext.cartItems.FirstOrDefault(ci=> ci.CartId == cartId && ci.ProductId == productId);
            if (item != null)
            {
                _dbContext.cartItems.Remove(item);
            }
        }

        public void Delete(Cart entity)
        {
            _dbContext.Carts.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Cart? Get(int id)
        {
            return _dbContext.Carts.Find(id);
        }

        public List<Cart> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cart? GetByCustomerId(int customerId)
        {
            return _dbContext.Carts.FirstOrDefault(c => c.CustomerId == customerId);
        }
        public void Update(Cart cart)
        {
            _dbContext.Carts.Update(cart);
        }
        public CartItem GetItem(int cartId,int productId)
        {
           return _dbContext.cartItems.FirstOrDefault(ci => ci.CartId == cartId && ci.ProductId == productId);
        }

        public void UpdateItem(CartItem item)
        {
            _dbContext.cartItems.Update(item);
        }
    }
}
