using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProductVarientRepository : IProductVarientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductVarientRepository(ApplicationDbContext dbContext) =>
           _dbContext = dbContext;
        
        public void Add(ProductVarient entity) =>
            _dbContext.ProductVarients.Add(entity);

        public void AddRange(List<ProductVarient> productVarients) =>
            _dbContext.ProductVarients.AddRange(productVarients);

        public void Delete(ProductVarient entity) =>
            _dbContext.ProductVarients.Remove(entity);
        
        public void DeleteRange(List<ProductVarient> productVarients) =>
            _dbContext.ProductVarients.RemoveRange(productVarients);

        public ProductVarient? Get(int id) =>
           GetAll().FirstOrDefault(pv => pv.Id == id);

        public List<ProductVarient> Get(string name) =>
           GetAll()
            .Where(pv => pv.ColoredProduct.Product.Name == name)
            .ToList();

        public List<ProductVarient> GetAll() =>
            _dbContext.ProductVarients
            .Include(pv => pv.ColoredProduct).ThenInclude(pv => pv.Product)
            .Include(pv => pv.Size) 
            .ToList();

        public List<ProductVarient> GetByProductColored(int productId, int colorId) =>
           GetAll()
            .Where(pv => pv.ProductId == productId && pv.ColorId == colorId).ToList();

        public List<ProductVarient> GetBySize(int sizeId) =>
           GetAll()
            .Where(pv => pv.SizeId == sizeId).ToList();

        public void Update(ProductVarient entity) =>
            _dbContext.ProductVarients.Update(entity);
    }
}
