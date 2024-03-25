

namespace Services.Abstraction.DataServices;

public interface IAdminService
{
    public ICustomerService CustomerService { get; }
    public IProductService ProductService { get; }
    public ICategoryService CategoryService { get; }
    public IOrderService OrderService { get; }
    public ISallerService SallerService { get; }
    public ICartService CartService { get; }
    public IFavouriteService FavouriteService { get; }
    public IReviewService ReviewService { get; }
    public IGeneralService GeneralService { get; }
}
