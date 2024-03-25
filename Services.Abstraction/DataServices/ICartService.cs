using Contract;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.DataServices
{
    public interface ICartService
    {
        CartDto? Get(int id);
        CartDto? GetByCustomerId(int id);
        void Update(int customerId);
        void UpdateItem(int cartId,int productId, Dictionary<Properties, int> newValues);
        void DeleteItem(int productId, int cartId);
        void AddItemToCart(ItemDto itemDto,int cartId);
        CartItem Update_Item(CartItem cartItem, Dictionary<Properties, int> newValues);     
         
    }
}
