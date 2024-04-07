using Contract;
using Contract.Order;
using Domain.Entities;
using Domain.Entities.Other;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.Extenstions;
using System.Data;

namespace Services.DataServices
{
    public class OrderService : IOrderService
    {
        private readonly IAdminRepository _repository;

        public OrderService(IAdminRepository repository)
        {
            _repository = repository;
        }
        private void RemoveOrder(Order order, List<ProductsToOrderDtoNew> products)
        {
           var varients = _repository.productVarientBelongToOrderReposatory.GetAll()
                .Where(pvo => pvo.OrderId == order.Id)
                .Select(pvo => pvo.ProductVarient);
            foreach (var (item, product) in varients.Zip(products))
                _repository.ProductVarientRepository.AddQuntity(item, product.Quantity);
            
            _repository.OrderReposatory.Delete(order);
            _repository.SaveChanges();
        }

        private void UpdateState(Order order, OrderStates state, string comment)
        {
            order.State = state;
            order.Comment = comment;
        }
        
        public void Add(OrderDtoNew orderDtonewFromCustomer) // for customer
        {
            Order OrderEntity = new Order
            {
                OrderedDate = orderDtonewFromCustomer.OrderDate,
                ConfirmDate = null,
                CustomerAddress = orderDtonewFromCustomer.CustomerAddress,
                CustomerId = orderDtonewFromCustomer.CustomerId,
                State = OrderStates.Pending,

                TotalCost = orderDtonewFromCustomer.productsperOrder.Sum(p => p.TotalCost)
            };
            _repository.OrderReposatory.Add(OrderEntity);
            _repository.SaveChanges();

            foreach (var item in orderDtonewFromCustomer.productsperOrder)
            {
               
                ProductVarient? productVarient = _repository.ProductVarientRepository.Get(item.ProductVarientId);
               
                if (productVarient != null)
                {
                    try
                    {
                        _repository.ProductVarientRepository.AddQuntity(productVarient, -1 * item.Quantity);
                        _repository.ProductVarientRepository.Update(productVarient);
                    }
                    catch(NotAllowedException)
                    {
                        RemoveOrder(OrderEntity, orderDtonewFromCustomer.productsperOrder);
                    }

                    ProductVarientBelongToOrder productVarientBelongToOrderEntity = new ProductVarientBelongToOrder
                    {
                        TotalPrice  = item.TotalCost,
                        Quantity = item.Quantity,
                        OrderId = OrderEntity.Id,
                        ProductId = productVarient.ProductId,
                        ColorId = productVarient.ColorId,
                        SizeId = productVarient.SizeId
                    };
                    _repository.productVarientBelongToOrderReposatory.Add(productVarientBelongToOrderEntity);
                   
                }
            }
            _repository.SaveChanges();
        }
        public void Delete(int id)
        {
            var order = _repository.OrderReposatory.Get(id);
            if (order == null)
                throw new NotFoundException("Order");

            var varients = _repository
                .productVarientBelongToOrderReposatory
                .GetAll().Where(pvo => pvo.OrderId == id);

            foreach ( var varient in varients)
            {
                varient.ProductVarient.Quantity += varient.Quantity;
            }
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
        
        public void UpdateState(int id , OrderStates state, string comment)
        {
            var order = _repository.OrderReposatory.Get(id);
            if (order == null)
                throw new NotFoundException("Order");
            if (order.State == OrderStates.Pending)
            {
                if (state == OrderStates.Confirmed)
                {
                    UpdateState(order, state, comment);

                    order.ConfirmDate = DateTime.Now;
                    _repository.OrderReposatory.Update(order);
                    _repository.SaveChanges();
                }
              
                if (state == OrderStates.Rejected)
                {
                    if (order.ProductBelongToOrders != null)
                    {
                        foreach (var pveriant in order.ProductBelongToOrders)
                        {
                            var Products = pveriant.ProductVarient;
                            _repository.ProductVarientRepository
                                .AddQuntity(Products, pveriant.Quantity);         
                            _repository.ProductVarientRepository.Update(Products);
                        }
                    }

                    UpdateState(order, state, comment);
                    
                    _repository.OrderReposatory.Update(order);
                    _repository.SaveChanges();
                }
            }
            else if(order.State == OrderStates.Confirmed) 
            {
                if(state == OrderStates.Delivered)
                {
                    UpdateState(order, state, comment);

                    _repository.OrderReposatory.Update(order);
                    _repository.SaveChanges();
                }
            }
        }

        public int GetNumberOrders(OrderStates state) =>
            _repository.OrderReposatory.GetNumberOrders(state);

        public double GetProfit(OrderStates state) =>
            _repository.OrderReposatory.GetProfit(state);

        public List<ProfitDto> GetProfitByYear(OrderStates state) =>
            _repository.OrderReposatory.GetProfitByYear(state).ToProfitDto();

        public List<ProfitDto> GetProfitByWeek(OrderStates state) =>
            _repository.OrderReposatory.GetProfitByWeek(state).ToProfitDto();

        public List<ProfitWeekDto> GetProfitByWeekDay(OrderStates state) =>
            _repository.OrderReposatory.GetProfitByWeekDay(state).ToProfitWeekDto();

        public Payment GetPayment(int orderId)
        {
            var order = _repository.OrderReposatory.Get(orderId);

            if (order == null) throw new NotFoundException("Order");

            return order.Payment;
        }

        public void UpdatePayment(Payment payment)
        {
            var order = _repository.OrderReposatory.Get(payment.OrderId);

            if (order == null) throw new NotFoundException("Order");

            order.Payment = payment;
            _repository.SaveChanges();
        }

        public OrderStates GetOrderStates(int orderId)
        {
            var order = _repository.OrderReposatory.Get(orderId);

            if (order == null) throw new NotFoundException("Order");

            return order.State;
        }
    }
}
