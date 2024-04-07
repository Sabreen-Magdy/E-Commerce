using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProductColerdRepository : IProductColerdRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductColerdRepository(ApplicationDbContext dbContext) =>
           _dbContext = dbContext;

        private bool CanRemove(ColoredProduct product)
        {
            var varients = product.Varients.Select(v => v.ProductBelongToOrders);
            var count = varients.Select(v => v.Count(v =>
                v.Order.State == OrderStates.Pending
                || v.Order.State == OrderStates.Confirmed));

            return count.Sum() == 0;
        }


        public void Add(ColoredProduct entity) =>
            _dbContext.ColoredProducts.Add(entity);

        public void AddRange(List<ColoredProduct> coloredProductVarients) =>
            _dbContext.ColoredProducts.AddRange(coloredProductVarients);

        public void Delete(ColoredProduct entity)
        {
            if (CanRemove(entity))
                _dbContext.ColoredProducts.Remove(entity);
            else
                throw new NotAllowedException("This Colored Product has Orders in Progress");
        }
        public void DeleteRangee(List<ColoredProduct> coloredProductVarients) =>
            _dbContext.ColoredProducts.RemoveRange(coloredProductVarients);

        public ColoredProduct? Get(int id) =>
            GetAll().FirstOrDefault(cp => cp.Id == id);

        public List<ColoredProduct> Get(string name) =>
            _dbContext.ColoredProducts
            .Include(cp => cp.Product)
            .Include(cp => cp.Color)
            .Where(cp => cp.Product.Name == name).ToList();

        public List<ColoredProduct> GetAll() =>
            _dbContext.ColoredProducts
            .Include(cp => cp.Product)
            .Include(cp => cp.Color)
            .Include(cp=> cp.Varients).ToList();

        public List<ColoredProduct> GetByProduct(int productId) =>
            GetAll()
            .Where(cp => cp.Product.Id == productId).ToList();

        public void Update(ColoredProduct entity) =>
            _dbContext.ColoredProducts.Update(entity);
    }
}
