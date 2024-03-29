using Domain.Entities;

namespace Domain.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    int NumProduct(int categoryId);
}
