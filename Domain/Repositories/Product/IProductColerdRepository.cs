
using Domain.Entities;

namespace Domain.Repositories;

public interface IProductColerdRepository 
    : IBaseRepository<ColoredProduct>
{
    void AddRange(List<ColoredProduct> coloredProductVarients);
    void DeleteRangee(List<ColoredProduct> coloredProductVarients);

    List<ColoredProduct> GetByProduct(int productId);
}
