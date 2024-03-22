using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
        List<Review> GetAllReviewByCustomerId(int customerId);
        List<Review> GetAllReviewByProductId(int productId);
        void Add(Review review);
        void Update(Review review);
        void Delete(Review review);

    }
}
