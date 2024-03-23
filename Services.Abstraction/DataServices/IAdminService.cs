

namespace Services.Abstraction.DataServices;

public interface IAdminService
{
    public ICustomerService CustomerService { get; }
    public IProductService ProductService { get; }
    public ICategoryService CategoryService { get; }
    public IOrderService OrderService { get; }
}
