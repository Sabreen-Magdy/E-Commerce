using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICardRepositry : IBaseRepository<Cart>
    {
        public void AddItem(CartItem item);
        public void DeletItem(int itemId);
        public CartItem GetItem(int itemId);
        public void UpdateItem(CartItem item);
        public Cart? GetByCustomerId(int customerId);
    }
}
