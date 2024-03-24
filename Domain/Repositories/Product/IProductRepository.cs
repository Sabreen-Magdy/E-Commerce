
using Domain.Entities;

namespace Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    void AddReview(int rate);
    void DeleteReview(int rate);
}
