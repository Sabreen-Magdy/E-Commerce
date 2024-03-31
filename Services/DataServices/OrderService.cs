using Contract;
using Contract.Order;
using Domain.Entities;
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

        private void UpdateState(Order order, int state, string comment)
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
                State = 0,

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
        
        public void UpdateState(int id , int state, string comment)
        {
            var order = _repository.OrderReposatory.Get(id);
            if (order == null)
                throw new NotFoundException("Order");
            if (order.State == 0)
            {
                if (state == 1)
                {
                    UpdateState(order, state, comment);

                    order.ConfirmDate = DateTime.Now;
                    _repository.OrderReposatory.Update(order);
                    _repository.SaveChanges();
                }
              
                if (state == 2)
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
            else if(order.State == 1) 
            {
                if(state == 3)
                {
                    UpdateState(order, state, comment);

                    _repository.OrderReposatory.Update(order);
                    _repository.SaveChanges();
                }
            }
        }

        public int GetNumberOrders(int state) =>
            _repository.OrderReposatory.GetNumberOrders(state);

        public double GetProfit(int state) =>
            _repository.OrderReposatory.GetProfit(state);

        public List<ProfitDto> GetProfitByYear(int state) =>
            _repository.OrderReposatory.GetProfitByYear(state).ToProfitDto();

        public List<ProfitDto> GetProfitByWeek(int state) =>
            _repository.OrderReposatory.GetProfitByWeek(state).ToProfitDto();

        public List<ProfitWeekDto> GetProfitByWeekDay(int state) =>
            _repository.OrderReposatory.GetProfitByWeekDay(state).ToProfitWeekDto();
    }
}
