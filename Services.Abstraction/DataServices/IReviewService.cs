using Contract;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.DataServices
{
    public interface IReviewService
    {
        List<CustomerReviewDto> GetAllReviewsOfCustomer(int customerId);
        List<CustomerReviewDto> GetAllReviewsOfProduct(int productId);

        CustomerReviewDto? GetReviewOfCustomer(int customerId,int productId);
        void Add(CustomerReviewDto review);
        Review UpdateReview(Review review,
           Dictionary<Properties, object> newValues);
        void Update_Review(int id, Dictionary<Properties, object> newValues);
        void DeleteReview(int id);
        void Delete_Review(int customerId, int productId);
    }
}
