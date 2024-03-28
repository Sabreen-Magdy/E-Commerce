using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICardRepositry : IBaseRepository<CartItem>
    {
        //public void AddItem(CartItem item);
        //public void DeletItem(CartItem item);
        CartItem? GetItem(int customerID, int productVarientId);
        //public void UpdateItem(CartItem item);
        List<CartItem> GetByCustomerId(int customerId);

        void AddRange(List<CartItem> items);
    }
}
