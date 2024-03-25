
using Domain.Entities;

namespace Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    void AddReview(int productId, int rate);
    void DeleteReview(int productId, int rate);
}
