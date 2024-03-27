using Contract;
using Contract.Order;
using Domain.Entities;

namespace Services.Extenstions
{
    public static class orderExtention
    {
        //public static ProductVariantOrderDto ToProductBToOrderDto(this ProductVarient product, int quantity)
        //{
        //    if (product == null)
        //        throw new ArgumentNullException(nameof(product));
        //    var varient = product.ToProductVariantDto();
        //    return new()
        //    {
        //        Image = varient.coloredimage,
        //        Price = varient.Price * quantity,
        //        ProductName = product.ColoredProduct.Product.Name,
        //        ProductVarientId = product.Id,
        //        Quantity = quantity,
        //    };
        //}

        public static Order ToOrderEntity(this OrderDto order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return new()
            {
                ConfirmDate = order.ConfirmDate,
                OrderedDate = order.OrderDate,
                CustomerAddress = order.CustomerAddress,
                State = order.State,
                TotalCost = order.OrderTotalCost,
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

            var orderBlist = order.ProductBelongToOrders;
            
            //item.ProductVarient.ToProductVariantDto(),

            var productsperOrderprop = new List<ProductBToOrderDto>();
            foreach (var item in orderBlist)
                productsperOrderprop.Add(new()
                {
                    ProductVarientId = item.ProductVarient.Id,
                    Quantity = item.Quantity,
                    Image = item.ProductVarient.ColoredProduct.Image,
                    ProductName = item.ProductVarient.ColoredProduct.Product.Name,
                    TotalCost = item.Quantity * item.ProductVarient.UnitPrice
                });

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
                ProductsperOrders = productsperOrderprop,
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
