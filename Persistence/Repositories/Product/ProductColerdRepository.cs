using Domain.Entities;
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

      
        public void Add(ColoredProduct entity) =>
            _dbContext.ColoredProducts.Add(entity);

        public void AddRange(List<ColoredProduct> coloredProductVarients) =>
            _dbContext.ColoredProducts.AddRange(coloredProductVarients);

        public void Delete(ColoredProduct entity) =>
            _dbContext.ColoredProducts.Remove(entity);

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
            .Include(cp => cp.Color).ToList();

        public List<ColoredProduct> GetByProduct(int productId) =>
            GetAll()
            .Where(cp => cp.Product.Id == productId).ToList();

        public void Update(ColoredProduct entity) =>
            _dbContext.ColoredProducts.Update(entity);
    }
}
