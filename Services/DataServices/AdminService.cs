using Domain.Repositories;
using Services.Abstraction.DataServices;

namespace Services.DataServices;

public sealed class AdminService : IAdminService
{
    private readonly ICustomerService _customerService;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    public AdminService(IAdminRepository repositoryAdmin)
    {
        _customerService = new CustomerService(repositoryAdmin);
        _productService = new ProductService(repositoryAdmin);
        _categoryService = new CategoryService(repositoryAdmin);
    }

    public ICustomerService CustomerService => _customerService;
    public IProductService ProductService => _productService;
    public ICategoryService CategoryService => _categoryService;
}
