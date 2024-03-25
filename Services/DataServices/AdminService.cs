using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.DataServices;

namespace Services;

public sealed class AdminService : IAdminService
{
    private readonly ICustomerService _customerService;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IOrderService _OrderService;
    private readonly ISallerService _SallerService;
    private readonly ICartService _cartService;
    private readonly IFavouriteService _favoriteService;
    private readonly IReviewService _reviewService;


    public AdminService(IAdminRepository repositoryAdmin)
    {
        _customerService = new CustomerService(repositoryAdmin);
        _productService = new ProductService(repositoryAdmin);
        _categoryService = new CategoryService(repositoryAdmin);
        _OrderService = new OrderService(repositoryAdmin);
        _SallerService = new SalleryService(repositoryAdmin);
        _cartService=new CartService(repositoryAdmin);
        _favoriteService=new FavouriteService(repositoryAdmin);
        _reviewService=new ReviewService(repositoryAdmin);
    }

    public ICustomerService CustomerService => _customerService;
    public IProductService ProductService => _productService;
    public ICategoryService CategoryService => _categoryService;

    public IOrderService OrderService => _OrderService;

    public ISallerService SallerService => _SallerService;

    public ICartService CartService => _cartService;

    public IFavouriteService FavouriteService => _favoriteService;

    public IReviewService ReviewService => _reviewService;
}


