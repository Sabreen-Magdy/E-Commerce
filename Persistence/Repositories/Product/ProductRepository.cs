using Domain.Entities;
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

        public void Add(Product entity) =>
            _dbContext.Products.Add(entity);

        public void AddReview(int productId, int rate)
        {
            var product = Get(productId);

            float oldRate = product!.AvgRate * product!.NumberReviews;
            product!.NumberReviews++;
            product!.AvgRate = (oldRate + rate) / product!.NumberReviews;

        }
        public void Delete(Product entity) =>
            _dbContext.Products.Remove(entity);

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
            GetAll().Where(p => p.Name == name).ToList();


        public List<Product> GetAll()
        {
            return _dbContext.Products.Include(p => p.ColoredProducts).ToList();
        //.Include(p => p.ColoredProducts).ThenInclude(pc => pc.Varients).ThenInclude(v => v.Size).Include(pc => pc.ColoredProducts).ThenInclude(cp => cp.Color).Include(p=>p.Reviews).Include(p=>p.Favourites).Include(p=>p.Saller).Include(p=>p.ProductCategories).ToList();
        //ThenInclude(pc => pc.Varients ).ThenInclude(v=>v.Size).Include(pc=>pc.ColoredProducts).ThenInclude(cp=>cp.Color).ToList();
        //        return _dbContext.Products
        //.Include(p => p.ColoredProducts)
        //    .ThenInclude(cp => cp.Color)   // Include Color within ColoredProducts
        //.Include(p => p.ColoredProducts)
        //    .ThenInclude(cp => cp.Varients) // Include Varients within ColoredProducts
        //        .ThenInclude(v => v.Size)   // Include Size within Varients
        //.Include(p => p.Reviews)
        //.Include(p => p.Favourites)
        //.Include(p => p.Saller)
        //.Include(p => p.ProductCategories)
        //.ToList();

        }

        //_dbContext.Products
        //.Include(p => p.ColoredProducts).ThenInclude(pc => pc.Varients).ThenInclude(v => v.Size).Include(pc => pc.ColoredProducts).ThenInclude(cp => cp.Color).Include(p=>p.Reviews).Include(p=>p.Favourites).Include(p=>p.Saller).Include(p=>p.ProductCategories).ToList();
        //ThenInclude(pc => pc.Varients ).ThenInclude(v=>v.Size).Include(pc=>pc.ColoredProducts).ThenInclude(cp=>cp.Color).ToList();
        //    _dbContext.Products
        //.Include(p => p.ColoredProducts)
        //    .ThenInclude(cp => cp.Varients)
        //        .ThenInclude(v => v.Size)
        //.Include(p => p.ColoredProducts)
        //    .ThenInclude(cp => cp.Color)
        //.ToList();

        public void Update(Product entity) =>
            _dbContext.Products.Update(entity);
    }
}
