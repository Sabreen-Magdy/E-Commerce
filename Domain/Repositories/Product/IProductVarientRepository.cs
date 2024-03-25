

using Domain.Entities;

namespace Domain.Repositories;

public interface IProductVarientRepository 
    : IBaseRepository<ProductVarient>
{
    void AddRange(List<ProductVarient> productVarients);
    void DeleteRange(List<ProductVarient> productVarients);
  
    List<ProductVarient> GetByProductColored(int productId, int colorId);
    List<ProductVarient> GetBySize(int sizeId);

}
