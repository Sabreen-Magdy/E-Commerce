﻿using Domain;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

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
        =>
            GetAll().FirstOrDefault(r => r.Id == id);
        

        public List<Review> Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetAll() =>
            _dbContext.Reviews
            .Include(r => r.Product)
            .ToList();
        
        public List<Review> GetAllReviewByCustomerId(int customerId) =>
             GetAll().Where(r=>r.CustomerId== customerId).ToList();
        

        public List<Review> GetAllReviewByProductId(int productId) =>
             GetAll().Where(r => r.ProductId == productId).ToList();

        public Review? GetByCustomerProduct(int customerID, int productID)
        {
           return GetAll().FirstOrDefault(r => r.CustomerId == customerID && r.ProductId == productID);
        }

        public void Update(Review review)
        {
            _dbContext.Reviews.Update(review);
        }
    }
}
