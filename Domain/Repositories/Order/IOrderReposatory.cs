using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderReposatory : IBaseRepository<Order>
    {
        List<Order> GetByCustomer(int customerID);
        List<Order> GetByProduct(int productID);
    }
}
