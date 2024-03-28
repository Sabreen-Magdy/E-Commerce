using Contract;
using Contract.OrderItem;
using Domain.Enums;


namespace Services.Abstraction.DataServices
{
    public interface ICartService
    {
        CartItemDto Get(int id);
      
        void AddCart(int customerId, List<ItemNewDto> items);
        void AddItem(int customerId, ItemNewDto item);
        void DeleteItem(int id);
        void DeleteItem(int customerId, int productVarientId);
        CartDto GetByCustomerId(int customerId);
        CartItemDto Get(int customerId, int productVarientId);
        void Update(int customerId, int productVarientId, Dictionary<Properties, int> newValues);
    }
}
