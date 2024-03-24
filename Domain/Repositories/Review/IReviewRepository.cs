using Domain.Entities;

namespace Domain.Repositories
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        List<Review> GetByCustomer(int customerID);
        List<Review> GetByProduct(int productID);
        Review GetByCustomerProduct(int customerID, int productID);
        List<Review> GetAllReviewByCustomerId(int customerId);
        List<Review> GetAllReviewByProductId(int productId);
    }
}
