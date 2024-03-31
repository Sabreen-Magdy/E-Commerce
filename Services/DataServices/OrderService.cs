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
        private void RemoveOrder(Order order, List<ProductsToOrderDtoNew> products)
        {
           var varients = _repository.productVarientBelongToOrderReposatory.GetAll()
                .Where(pvo => pvo.OrderId == order.Id)
                .Select(pvo => pvo.ProductVarient);
            foreach (var (item, product) in varients.Zip(products))
                    item.Quantity -= product.Quantity;
            
            _repository.OrderReposatory.Delete(order);
            _repository.SaveChanges();
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
                    int newQuan = productVarient.Quantity - item.Quantity;
                    if (newQuan < 0)
                    {
                        RemoveOrder(OrderEntity, orderDtonewFromCustomer.productsperOrder);
                        throw new NotAllowedException("This Quantity Not Availabe in Stock, Order Cancelled");
                    }
                    productVarient.Quantity = newQuan;
                    _repository.ProductVarientRepository.Update(productVarient);

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
        public void Updatestatus(int id , int status)
        {
            var order = _repository.OrderReposatory.Get(id);
            if (order == null)
                throw new NotFoundException("Order");
            if (order.State == 0)
            {
                if (status == 1)
                {
                    order.State = status;

                    order.ConfirmDate = DateTime.Now;
                    _repository.OrderReposatory.Update(order);
                    _repository.SaveChanges();
                }
               

                if (status == 2)
                {
                    order.State = status;
                    _repository.OrderReposatory.Update(order);
                    _repository.SaveChanges();

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
            else if(order.State == 1) 
            {
                if(status == 3)
                {
                    order.State = status;
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
