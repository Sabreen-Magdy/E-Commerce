using Contract;
using Contract.Order;
using Domain.Entities.Other;
using Domain.Enums;

namespace Services.Abstraction.DataServices
{
    public interface IOrderService 
    {
        public List<OrderDto> GetAll();
        public OrderDto Get(int id);
        public List<OrderDto> Get(string Name);
        public void Add(OrderDtoNew DTO);
        public void Update(OrderDto DTO);
        public void Delete(int id);
        public void UpdateState(int id, OrderStates status, string comment);
        int GetNumberOrders(OrderStates state);
        double GetProfit(OrderStates state);

        List<ProfitDto> GetProfitByYear(OrderStates state);
        List<ProfitDto> GetProfitByWeek(OrderStates state);
        List<ProfitWeekDto> GetProfitByWeekDay(OrderStates state);

        OrderStates GetOrderStates(int orderId);

        Payment GetPayment(int orderId);
        void UpdatePayment(Payment payment);
    }
}
