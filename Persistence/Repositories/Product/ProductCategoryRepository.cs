using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context) =>
            _context = context;

        public void Add(ProductCategory entity) =>
            _context.ProductCategories.Add(entity);
    
        public void Delete(ProductCategory entity) =>
            _context.ProductCategories.Remove(entity);

        public ProductCategory? Get(int id) =>
            GetAll().FirstOrDefault(pc => pc.Id == id);
        public ProductCategory? Get(int productId, int categoryId) =>
           GetAll().FirstOrDefault(
               pc => pc.ProductId == productId && pc.CategoryId == categoryId);

        public List<ProductCategory> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> GetAll() =>
            _context.ProductCategories
            .Include(pc => pc.Product)
            .Include(pc => pc.Category)
            .ToList();

        public void Update(ProductCategory entity) =>
            _context.ProductCategories.Update(entity);
    }
}
