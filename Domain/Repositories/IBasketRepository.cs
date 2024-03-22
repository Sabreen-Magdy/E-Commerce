using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBasketRepository
    {
        BasketCustomer GetBasket(string basketId);
        void UpdateBasket(BasketCustomer basketCustomer);
        void DeleteBasket(string basketId);
    }
}
