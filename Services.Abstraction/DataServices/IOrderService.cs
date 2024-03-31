﻿using Contract;
using Contract.Order;

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
        public void UpdateState(int id, int status, string comment);
        int GetNumberOrders(int state);
        double GetProfit(int state);

        List<ProfitDto> GetProfitByYear(int state);
        List<ProfitDto> GetProfitByWeek(int state);
        List<ProfitWeekDto> GetProfitByWeekDay(int state);
    }
}
