using Domain.Entities;

namespace Domain.Repositories;

public interface IProductVarientRepository 
    : IBaseRepository<ProductVarient>
{
    void AddRange(List<ProductVarient> productVarients);
    void DeleteRange(List<ProductVarient> productVarients);
  
    void AddQuntity(ProductVarient productVarients, int newQuntity);
    List<ProductVarient> GetByProductColored(int productId, int colorId);
    List<ProductVarient> GetBySize(int sizeId);

}
