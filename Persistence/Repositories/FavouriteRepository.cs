using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FavouriteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Favourite favourite)
        {
            _dbContext.Favourites.Add(favourite);
        }

        public void Delete(int productId,int customerId)
        {
            var fav = _dbContext.Favourites.FirstOrDefault(f=>f.CustomerId==customerId&&f.ProductId==productId);
            if (fav != null)
            {
                _dbContext.Favourites.Remove(fav);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Favourite entity)
        {
            _dbContext.Favourites.Remove(entity);
        }

        public Favourite? Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Favourite> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Favourite> GetAll()
        {
            return _dbContext.Favourites.ToList();
        }

        public List<Favourite> GetByCustomer(int customerID)
        {
            return _dbContext.Favourites.Where(f => f.CustomerId == customerID).ToList();
        }

        public Favourite? GetByCustomerProduct(int customerId,int productId)
        {
            return _dbContext.Favourites.FirstOrDefault(f => f.CustomerId == customerId&&f.ProductId==productId);
        }

        public List<Favourite> GetByProduct(int productID)
        {
            return _dbContext.Favourites.Where(f => f.ProductId == productID).ToList();
        }

        public void Update(Favourite fav)
        {
            _dbContext.Favourites.Update(fav);
        }
    }
}
