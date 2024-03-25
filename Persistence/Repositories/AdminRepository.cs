
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly ApplicationDbContext _context;

    private ICustomerRepository _customerRepository;
    private ISallerRepositry _sallerRepositry;
    private IProductRepository _productRepository;
    private ICategoryRepository _categoryRepository;
    private IProductCategoryRepository _productCategoryRepository;
    private IProductColerdRepository _productColerdRepository;
    private IProductVarientRepository _productVarientRepository;
    private IOrderReposatory _OrderReposatory;
    private IFavouriteRepository _favouriteRepository;
    private ICardRepositry _cartRepository;
    private IReviewRepository _reviewwRepository;
    private IProductVarientBelongToOrderReposatory _productVarientBelongToOrderReposatory;

    public AdminRepository(ApplicationDbContext context) =>
        _context = context;
   
    public ICustomerRepository CustomerRepository
    {
        get
        {
            if (_customerRepository == null)
                _customerRepository = new CustomerRepository(_context);

            return _customerRepository;
        }
    }
    public ISallerRepositry SallerRepository
    {
        get
        {
            if (_sallerRepositry == null)
                _sallerRepositry = new SallerRepository(_context);

            return _sallerRepositry;
        }
    }
    public IProductVarientBelongToOrderReposatory productVarientBelongToOrderReposatory
    {
        get
        {
            if (_productVarientBelongToOrderReposatory == null)
                _productVarientBelongToOrderReposatory = new ProductVarientBelongToOrderReposatory(_context);

            return _productVarientBelongToOrderReposatory;
        }
    }
    public IProductRepository ProductRepository
    {
        get
        {
            if (_productRepository == null)
            { }
            //_productRepository = new ProductRepository(_context);

            return _productRepository;
        }
    }
    public IOrderReposatory OrderReposatory
    {
        get
        {
            if (_OrderReposatory == null)

                _OrderReposatory = new OrderRepository(_context);

            return _OrderReposatory;
        }
    }

    public ICategoryRepository CategoryRepository
    {
        get
        {
            if (_categoryRepository == null) { }
            // _categoryRepository = new CustomerRepository(_context);

            return _categoryRepository;
        }
    }

    public IProductCategoryRepository ProductCategoryRepository
    {
        get
        {
            if (_productCategoryRepository == null) { }
            //_productCategoryRepository = new CustomerRepository(_context);

            return _productCategoryRepository;
        }
    }

    public IProductColerdRepository ProductColerdRepository
    {
        get
        {
            if (_productColerdRepository == null) { }
            //_productColerdRepository = new CustomerRepository(_context);

            return _productColerdRepository;
        }
    }

    public IProductVarientRepository ProductVarientRepository
    {
        get
        {
            if (_productVarientRepository == null) { }
            //_productVarientRepository = new CustomerRepository(_context);

            return _productVarientRepository;
        }
    }

    public IFavouriteRepository FavouriteRepository
    {
        get
        {
            if (_favouriteRepository == null)
                _favouriteRepository = new FavouriteRepository(_context);

            return _favouriteRepository;
        }
    }

    public ICardRepositry CardRepositry
    {
        get
        {
            if (_cartRepository == null)
                _cartRepository = new CartRepository(_context);

            return _cartRepository;
        }
    }

    public IReviewRepository ReviewRepository
    {
        get
        {
            if (_reviewwRepository == null)
                _reviewwRepository = new ReviewRepository(_context);

            return _reviewwRepository;
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
