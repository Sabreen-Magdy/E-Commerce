using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
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

        private bool CanRemove(ProductVarient product)
        {
            return product.ProductBelongToOrders.Count(v =>
                v.Order.State == OrderStates.Pending
                || v.Order.State == OrderStates.Confirmed) == 0;
        }


        public void Add(ProductVarient entity) =>
            _dbContext.ProductVarients.Add(entity);

        public void AddRange(List<ProductVarient> productVarients) =>
            _dbContext.ProductVarients.AddRange(productVarients);

        public void Delete(ProductVarient entity)
        {
            if(CanRemove(entity))
                _dbContext.ProductVarients.Remove(entity);
            else
                throw new NotAllowedException("This Product Varient has Orders in Progress");
        }
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

        public void AddQuntity(ProductVarient productVarient, int newQuntity)
        {
           
            if (productVarient == null)
                throw new NotFoundException("Product Varient");
            
            int res = productVarient.Quantity + newQuntity;
            if (res < 0)
                throw new NotAllowedException("Not Available Quantity in Stock");
            productVarient.Quantity = res;
        }
    }
}
