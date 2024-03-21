

using Domain.Entities;

namespace Domain.Repositories;

public interface IProductVarientRepository 
    : IBaseRepository<ProductVarient>
{
    void AddRange(List<ProductVarient> productVarients);
    void DeleteRange(List<ProductVarient> productVarients);
  
    List<ProductVarient> GetByProductColored(int productColoredId);
    List<ProductVarient> GetBySize(int sizeId);

}
