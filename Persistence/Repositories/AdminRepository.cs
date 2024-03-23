
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly ApplicationDbContext _context;

    private ICustomerRepository _customerRepository;
    private IProductRepository _productRepository;
    private ICategoryRepository _categoryRepository;

    private IProductCategoryRepository _productCategoryRepository;
    private IProductColerdRepository _productColerdRepository;
    private IProductVarientRepository _productVarientRepository;
    private ISallerRepositry _sallerRepositry;
    private IOrderReposatory _orderReposatory;
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
    public IProductRepository ProductRepository
    {
        get
        {
            if (_productRepository == null)
            { }
                //_productRepository = new CustomerRepository(_context);

            return _productRepository;
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



    public IOrderReposatory OrderReposatory
    {
        get
        {
            if (_orderReposatory == null) { }
            //_orderReposatory = new ord(_context);

            return _orderReposatory;
        }
    }

    public ISallerRepositry SallerRepository
    {
        get
        {
            if (_sallerRepositry == null) { }
            //_productVarientRepository = new CustomerRepository(_context);

            return _sallerRepositry;
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
