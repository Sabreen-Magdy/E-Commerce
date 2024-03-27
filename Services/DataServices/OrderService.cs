using Contract;
using Contract.Order;
using Domain.Entities;
using Domain.Exceptions;
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

        public void Add(OrderDtoNew orderDtonewFromCustomer) // for customer
        {
            // Order OrderEntity = orderDto.ToOrderEntity();
           
            Order OrderEntity = new Order
            {
                OrderedDate = orderDtonewFromCustomer.OrderDate,
                ConfirmDate = null,
                CustomerAddress = orderDtonewFromCustomer.CustomerAddress,
                CustomerId = orderDtonewFromCustomer.CustomerId,
                //Customer = _repository.CustomerRepository.Get(orderDtonewFromCustomer.CustomerId),
                State = 0, 
                TotalCost = orderDtonewFromCustomer.OrderTotalCost, 
               // ProductBelongToOrders = productVarientBelongToOrders
                // ProductBelongToOrder = _repository.ProductVarientBelongToOrderReposatory.
            };
            _repository.OrderReposatory.Add(OrderEntity);
            _repository.SaveChanges();

            //List<ProductVarientBelongToOrder> productVarientBelongToOrders = new List<ProductVarientBelongToOrder>();

            foreach (var item in orderDtonewFromCustomer.productsperOrder)

            {
               
                ProductVarient? productVarient = _repository.ProductVarientRepository.Get(item.ProductVarientId);
               
                if (productVarient != null)
                {
                    int newQuan = productVarient.Quantity - item.Quantity;
                    if (newQuan < 0)
                        throw new NotAllowedException("This Quantity Not Availabe in Stock ");
                    productVarient.Quantity = newQuan;

                    _repository.ProductVarientRepository.Update(productVarient);
                    _repository.SaveChanges();

                    ProductVarientBelongToOrder productVarientBelongToOrderEntity = new ProductVarientBelongToOrder
                    {
                        TotalPrice = item.TotalCostPerQuantity,
                        Quantity = item.Quantity,
                        OrderId = OrderEntity.Id,
                        //Order = OrderEntity,
                        ProductId = productVarient.ProductId,
                        ColorId = productVarient.ColorId,
                        SizeId = productVarient.SizeId,
                        //ProductVarient = productVarient
                    };
                   // productVarientBelongToOrders.Add(productVarientBelongToOrderEntity);
                    _repository.productVarientBelongToOrderReposatory.Add(productVarientBelongToOrderEntity);
                    _repository.SaveChanges();
                }
            }
        }

        //public void Add(OrderDto DTO)
        //{
        //    throw new NotImplementedException();
        //}

        public void Delete(int id)
        {
            var order = _repository.OrderReposatory.Get(id);
            if (order == null)
                throw new NotFoundException("Order");
            _repository.OrderReposatory.Delete(order);
            _repository.SaveChanges();  
        }

        public OrderDto Get(int id) // for admin
        {
            var order = _repository.OrderReposatory.Get(id);
            if (order == null)
                throw new NotFoundException("Order");
            return order.ToOrderDto();
        }

        public List<OrderDto> Get(string Name)
        {
            var order = _repository.OrderReposatory.Get(Name);
            if (order == null)
                throw new NotFoundException("Order");
            return order.ToOrderDto();
        }

        //public OrderDto Get(string Name)
        //{
        //    var order = _repository.OrderReposatory.Get(Name);
        //    return order.ToOrderDto();
        //}

        public List<OrderDto> GetAll()
        {
            var orders = _repository.OrderReposatory.GetAll();

            return orders.ToOrderDto();
        }

        public void Update(OrderDto DTO)
        {
            _repository.OrderReposatory.Update(DTO.ToOrderEntity());
            _repository.SaveChanges();
        }
        public void Updatestatus(int id , int status)
        {
            var order = _repository.OrderReposatory.Get(id);
            if (order == null)
                throw new NotFoundException("Order");
            order.State = status;
            order.ConfirmDate = DateTime.Now;
            _repository.OrderReposatory.Update(order);
            _repository.SaveChanges();
            if (status == 2)
            {
                if (order.ProductBelongToOrders != null)
                {
                    foreach (var pveriant in order.ProductBelongToOrders)
                    {
                        var Products = pveriant.ProductVarient;
                        Products.Quantity = Products.Quantity + pveriant.Quantity;
                        _repository.ProductVarientRepository.Update(Products);
                        _repository.SaveChanges();
                    }
                }
            }
        }

    }
}
