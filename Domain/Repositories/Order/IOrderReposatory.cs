using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories
{
    public interface IOrderReposatory : IBaseRepository<Order>
    {
        List<Order> GetByCustomer(int customerID);
        int GetNumberOrders(OrderStates state);
        double GetProfit(OrderStates state);
        List<KeyValuePair<int, double>> GetProfitByYear(OrderStates state);
        List<KeyValuePair<int, double>> GetProfitByWeek(OrderStates state);
        List<KeyValuePair<DayOfWeek, double>> GetProfitByWeekDay(OrderStates state);
    }
}
