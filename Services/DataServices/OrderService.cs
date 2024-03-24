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
                productVarientBelongToOrders.Add(new ProductVarientBelongToOrder {
                    TotalPrice = item.TotalCostPerQuantity,
                    Quantity = item.Quantity,
                    OrderId = item.OrderId,
                    //ProductId = item.products.ProductId,
                    //ColorId = item.ColorId,
                    //SizeId = item.products.Size.
                    ProductVarient = productVarient

                });
            }
            Order OrderEntity = new Order
            {
                OrderedDate = orderDtonewFromCustomer.OrderDate,
                ConfirmDate = null,
                CustomerAddress = orderDtonewFromCustomer.CustomerAddress,
                CustomerId = orderDtonewFromCustomer.CustomerId,
                //Customer = _repository.CustomerRepository.Get(orderDtonewFromCustomer.CustomerId),
                State = orderDtonewFromCustomer.State, 
                TotalCost = orderDtonewFromCustomer.OrderTotalCost, 
                ProductBelongToOrders = productVarientBelongToOrders
                // ProductBelongToOrder = _repository.ProductVarientBelongToOrderReposatory.
            };


            _repository.OrderReposatory.Add(OrderEntity);
            _repository.SaveChanges();
            
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
