using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) =>
           _dbContext = dbContext;

        private bool CanRemove(Product product)
        {
            var varients = product.ColoredProducts.Select(cp => cp.Varients).ToList();
            if (varients != null)
            {
                var varientsOrders = varients.SelectMany(v => v, (v, vv) => vv.ProductBelongToOrders).ToList();

                if (varientsOrders != null)
                {
                    var count = varientsOrders.Select(v => v != null? v.Count(v =>  v.Order != null &&
                                                     (v.Order.State == OrderStates.Pending
                                                     || v.Order.State == OrderStates.Confirmed)):0
                    );

                    return count.Sum() == 0;
                }
                else return true;
            }
            else return true;
        }


        public void Add(Product entity) =>
            _dbContext.Products.Add(entity);

        public void AddReview(int productId, int rate)
        {
            var product = Get(productId);

            float oldRate = product!.AvgRate * product!.NumberReviews;
            product!.NumberReviews++;
            product!.AvgRate = (oldRate + rate) / product!.NumberReviews;

        }
        public void Delete(Product entity)
        {
            if (CanRemove(entity))
                _dbContext.Products.Remove(entity);
            else
                throw new NotAllowedException("This Product has Orders in Progress");
        }
        public void DeleteReview(int productId, int rate)
        {
            var product = Get(productId);

            float oldRate = product!.AvgRate * product!.NumberReviews;
            product!.NumberReviews--;
            product!.AvgRate = (oldRate - rate) / product!.NumberReviews;
        }

        public Product? Get(int id) =>
            GetAll().Find(p => p.Id == id);

        public List<Product> Get(string name) =>
            GetAll().Where(p => p.Name.Contains(name.ToLower())).ToList();
        

        public List<Product> GetAll() =>
            _dbContext.Products
            .Include(p => p.ColoredProducts)
            .ThenInclude(cp => cp.Varients).ThenInclude(v => v.Size)
            .ThenInclude(cp => cp.Varients).ThenInclude(v => v.ProductBelongToOrders)
            .Include(p => p.ColoredProducts)
            .ThenInclude(cp => cp.Color)
            .Include(p => p.Reviews)
            //.Include(p => p.ProductCategories)
            //.ThenInclude(cp => cp.Category)
            .ToList();

        public int GetLength() => _dbContext.Products.Count();

        public void Update(Product entity) =>
            _dbContext.Products.Update(entity);
    }
}
