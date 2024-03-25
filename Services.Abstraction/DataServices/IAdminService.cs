﻿

namespace Services.Abstraction.DataServices;

public interface IAdminService
{
    public ICustomerService CustomerService { get; }
    public IProductService ProductService { get; }
    public ICategoryService CategoryService { get; }
    public IOrderService OrderService { get; }
    public ISallerService SallerService { get; }
    ICartService CartService { get; }
    IFavouriteService FavouriteService { get; }
    IReviewService ReviewService { get; }
}
