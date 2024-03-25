using Contract;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.Extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataServices
{
    public class ReviewService : IReviewService
    {
        private readonly IAdminRepository _repository;

        public ReviewService(IAdminRepository repository)
            => _repository = repository;

        public void Add(CustomerReviewDto review)
        {
            _repository.ReviewRepository.Add(review.ToReviewEntity());
            _repository.SaveChanges();
        }
        public void DeleteReview(int CustomerId)
        {
            var rev = _repository.ReviewRepository.Get(CustomerId);
            if (rev is null)
                throw new NotFoundException("rev");
            else
            {
                _repository.ReviewRepository.Delete(rev);
                _repository.SaveChanges();
            }
        }

        public void Delete_Review(int customerId, int productId)
        {
            var rev = _repository.ReviewRepository.GetByCustomerProduct(customerId, productId);
            if (rev is null)
                throw new NotFoundException("rev");
            else
            {
                _repository.ReviewRepository.Delete(rev);
                _repository.SaveChanges();
            }
        }

        public List<CustomerReviewDto> GetAllReviewsOfCustomer(int customerId)=>
            _repository.ReviewRepository
                       .GetAllReviewByCustomerId(customerId)
                       .ToCustomerReview();
        

        public List<ProductReviewDto> GetAllReviewsOfProduct(int productId) =>
            _repository.ReviewRepository
                   .GetAllReviewByProductId(productId)
                   .ToProductReview();

        public CustomerReviewDto? GetReviewOfCustomer(int customerId, int productId)
        {
            var rev = _repository.ReviewRepository.GetByCustomerProduct(customerId, productId);
            return rev.ToCustomerReview();
        }

        public ProductReviewDto? GetReviewOfProduct(int customerId, int productId)
        {
            var rev = _repository.ReviewRepository.GetByCustomerProduct(customerId, productId);
            return rev.ToProductReview();
        }

        public Review UpdateReview(Review review,
           Dictionary<Properties, object> newValues)
        {
            foreach (var item in newValues)
            {
                switch (item.Key)
                {
                    case Properties.Rate:
                        if (item.Value is int rate)
                            review.Rate = rate;
                        else
                            throw new ArgumentException($"Invalid type for Rate: {item.Value.GetType()}");
                        break;
                    case Properties.Comment:
                        if (item.Value is string comment)
                            review.Comment = comment;
                        else
                            throw new ArgumentException($"Invalid type for Comment: {item.Value.GetType()}");
                        break;
                     default:
                        throw new PropertyException(item.Key.ToString());
                }
            }
            return review;
        }
        public void Update_Review(int id, Dictionary<Properties, object> newValues)
        {
            var rev = _repository.ReviewRepository.Get(id);
            if (rev is null)
                throw new NotFoundException("Review");
            else
            {
                _repository.ReviewRepository.Update(UpdateReview(rev, newValues));
                _repository.SaveChanges();
            }
        }
    }
}
