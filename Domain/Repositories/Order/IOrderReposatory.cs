using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderReposatory : IBaseRepository<Order>
    {
        List<Order> GetByCustomer(int customerID);
        int GetNumberOrders(int state);
        double GetProfit(int state);
        List<KeyValuePair<int, double>> GetProfitByYear(int state);
        List<KeyValuePair<int, double>> GetProfitByWeek(int state);
        List<KeyValuePair<DayOfWeek, double>> GetProfitByWeekDay(int state);
    }
}
