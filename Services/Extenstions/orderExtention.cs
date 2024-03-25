using Contract;
using Contract.Order;
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
                TotalCost = order.OrderTotalCost ,
                CustomerId = order.CustomerId,
               //ProductBelongToOrders=
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

            var orderBlist = order.ProductBelongToOrders.Where(o => o.OrderId == order.Id).ToList();
            var productsperOrderprop = new List<ProductBToOrderDto>();
            foreach (var item in orderBlist)
            {
                productsperOrderprop.Add(new ProductBToOrderDto(){
                    //ColorId = item.ColorId ,
                    //OrderId = item.OrderId,
                    //ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalCostPerQuantity= item.TotalPrice,
                    products=item.ProductVarient.ToProductVariantDto(),
                });
            }
            return new()
            {
                ConfirmDate = order.ConfirmDate,
                OrderDate = order.OrderedDate,
                CustomerAddress = order.CustomerAddress,
                State = order.State,
                OrderTotalCost = order.TotalCost,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer.Name,
                OrderId= order.Id,
                productsperOrder = productsperOrderprop,
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
