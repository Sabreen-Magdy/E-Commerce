using Domain.Entities;

namespace Domain.Repositories;

public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
{
    ProductCategory? Get(int productId, int categoryId);
}
