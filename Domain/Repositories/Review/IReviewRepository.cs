using Domain.Entities;

namespace Domain.Repositories
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Review? GetByCustomerProduct(int customerID, int productID);
        List<Review> GetAllReviewByCustomerId(int customerId);
        List<Review> GetAllReviewByProductId(int productId);
    }
}
