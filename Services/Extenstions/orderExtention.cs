using Contract;
using Domain.Entities;

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

        public static List<Order> ToOrderEntity(this List<OrderDto> orders)
        {
            if (orders == null)
                throw new ArgumentNullException(nameof(orders));

           var orderEntities = new List<Order>();
            foreach (var order in orders)
                order.ToOrderEntity();

            return orderEntities;
        }

        public static OrderDto ToOrderDto(this Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return new()
            {
                ConfirmDate = order.ConfirmDate,
                OrderDate = order.OrderedDate,
                CustomerAddress = order.CustomerAddress,
                State = order.State,
                TotalCost = order.TotalCost,
                CustomerId = order.CustomerId,
            };
        }

        public static List<OrderDto> ToOrderDto(this List<Order> orders)
        {
            if (orders == null)
                throw new ArgumentNullException(nameof(orders));

            var orderDtos = new List<OrderDto>();
            foreach (var order in orders)
                orderDtos.Add(order.ToOrderDto());

            return orderDtos;
        }
    }
}
