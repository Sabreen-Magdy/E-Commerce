using Domain.Repositories;
using Services.Abstraction.DataServices;

namespace Services.DataServices;

public sealed class AdminService : IAdminService
{
    private readonly ICustomerService _customerService;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IOrderService _OrderService;
    public AdminService(IAdminRepository repositoryAdmin)
    {
        _customerService = new CustomerService(repositoryAdmin);
        _productService = new ProductService(repositoryAdmin);
        _categoryService = new CategoryService(repositoryAdmin);
        _OrderService = new OrderService(repositoryAdmin);
    }

    public ICustomerService CustomerService => _customerService;
    public IProductService ProductService => _productService;
    public ICategoryService CategoryService => _categoryService;

    public IOrderService OrderService => _OrderService;
}
