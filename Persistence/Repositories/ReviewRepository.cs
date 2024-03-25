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
    public class ReviewRepository: IReviewRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReviewRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public void Add(Review review)
        {
            _dbContext.Reviews.Add(review);
       
        }

        public void Delete(Review review)
        {
            var existingReview = _dbContext.Reviews.FirstOrDefault(r => r.CustomerId == review.CustomerId && r.ProductId == review.ProductId);
            
            if (existingReview != null)
            {
                _dbContext.Reviews.Remove(existingReview);
             
            }
        }

        public Review? Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Review> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetAll() =>
            _dbContext.Reviews.ToList();
        
        public List<Review> GetAllReviewByCustomerId(int customerId) =>
             _dbContext.Reviews.Where(r=>r.CustomerId== customerId).ToList();
        

        public List<Review> GetAllReviewByProductId(int productId) =>
             _dbContext.Reviews.Where(r => r.ProductId == productId).ToList();

        public List<Review> GetByCustomer(int customerID)
        {
            throw new NotImplementedException();
        }

        public Review GetByCustomerProduct(int customerID, int productID)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetByProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public void Update(Review review)
        {
            _dbContext.Reviews.Update(review);
        }
    }
}
