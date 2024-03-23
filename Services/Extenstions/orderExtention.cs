using Contract.Order;
using Contract.Product;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extenstions
{
    public static class orderExtention
    {

        public static Order ToOrderEntity(this OrderDto order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return new()
            {
                ConfirmDate = order.ConfirmDate,
                OrderedDate =order.OrderDate,
                CustomerAddress = order.CustomerAddress,
                State = order.State,    
                TotalCost = order.TotalCost ,
                CustomerId = order.CustomerId,
               
            };
        }
    }
}
