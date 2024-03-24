using Contract;
using Contract.Order;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.Extenstions;

namespace Services.DataServices
{
    public class OrderService : IOrderService
    {
        private readonly IAdminRepository _repository;

        public OrderService(IAdminRepository repository)
        {
            _repository = repository;
        }

        public void Add(OrderDtoNew orderDtonewFromCustomer)
        {
            // Order OrderEntity = orderDto.ToOrderEntity();
           
            Order OrderEntity = new Order
            {
                OrderedDate = orderDtonewFromCustomer.OrderDate,
                ConfirmDate = null,
                CustomerAddress = orderDtonewFromCustomer.CustomerAddress,
                CustomerId = orderDtonewFromCustomer.CustomerId,
                //Customer = _repository.CustomerRepository.Get(orderDtonewFromCustomer.CustomerId),
                State = orderDtonewFromCustomer.State, 
                TotalCost = orderDtonewFromCustomer.OrderTotalCost, 
               // ProductBelongToOrders = productVarientBelongToOrders
                // ProductBelongToOrder = _repository.ProductVarientBelongToOrderReposatory.
            };
            _repository.OrderReposatory.Add(OrderEntity);
            _repository.SaveChanges();

            List<ProductVarientBelongToOrder> productVarientBelongToOrders = new List<ProductVarientBelongToOrder>();

            foreach (var item in orderDtonewFromCustomer.productsperOrder)

            {
                // محمد لسه معملهاش implement
                ProductVarient productVarient = _repository.ProductVarientRepository.Get(item.products.Id);
                //{
                //    Id = item.products.Id,
                //    UnitPrice = item.products.Price,
                //    Discount = item.products.Discount,
                //    Quantity = item.products.Quantity,

                //};
                if (productVarient != null)
                {
                    ProductVarientBelongToOrder productVarientBelongToOrderEntity = new ProductVarientBelongToOrder
                    {
                        TotalPrice = item.TotalCostPerQuantity,
                        Quantity = item.Quantity,
                        OrderId = OrderEntity.Id,
                        Order = OrderEntity,
                        ProductId = productVarient.ProductId,
                        ColorId = productVarient.ColorId,
                        SizeId = productVarient.SizeId,
                        ProductVarient = productVarient

                    };
                    productVarientBelongToOrders.Add(productVarientBelongToOrderEntity);
                    _repository.productVarientBelongToOrderReposatory.Add(productVarientBelongToOrderEntity);
                    _repository.SaveChanges();
                }
                // مش عارفه المفروض اعمل update في ال order بالليست بتاعت ال علاثه ولا لا 
            }
        }

        public void Add(OrderDto DTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDto Get(string Name)
        {
            throw new NotImplementedException();
        }

        public List<OrderDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDto DTO)
        {
            throw new NotImplementedException();
        }

       
    }
}
