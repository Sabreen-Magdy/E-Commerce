using Domain.Entities;

namespace Domain.Repositories;

public interface ICustomerRepository :
    IBaseRepository<Customer>
{
    void Updatecust(int id , Customer customer);
    int GetNumberCustomers();
    Customer? GetByEmail(string email);
}
