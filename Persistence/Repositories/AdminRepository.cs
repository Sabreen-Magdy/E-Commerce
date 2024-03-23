﻿
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly ApplicationDbContext _context;

    private ICustomerRepository _customerRepository;
            
    private ISallerRepositry _SallerRepositry;
    private IProductRepository _productRepository;
    private ICategoryRepository _categoryRepository;

    private IProductCategoryRepository _productCategoryRepository;
    private IProductColerdRepository _productColerdRepository;
    private IProductVarientRepository _productVarientRepository;
    private IOrderReposatory _OrderReposatory ;
    private IProductVarientBelongToOrderReposatory _ProductVarientBelongToOrderReposatory;

    public AdminRepository(ApplicationDbContext context) =>
        _context = context;
    //public ICustomerRepository CustomerRepository;
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
            if (_SallerRepositry == null)
                _SallerRepositry = new SallerRepository(_context);

            return _SallerRepositry;
        }
    }
    public IProductVarientBelongToOrderReposatory ProductVarientBelongToOrderReposatory
    {
        get
        {
            if (_ProductVarientBelongToOrderReposatory == null)
                _ProductVarientBelongToOrderReposatory = new ProductVarientBelongToOrderReposatory(_context);

            return _ProductVarientBelongToOrderReposatory;
        }
    }
    //public ISallerRepositry SallerRepository
    //{
    //    get
    //    {
    //        if (_customerRepository == null)
    //            _customerRepository = new CustomerRepository(_context);

    //        return _customerRepository;
    //    }
    //}
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
    public IOrderReposatory OrderReposatory
    {
        get
        {
            if (_OrderReposatory == null)
            {
                _OrderReposatory = new OrderRepository(_context);
            }

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
    //ICustomerRepository IAdminRepository.CustomerRepository => throw new NotImplementedException();

    //public IOrderReposatory OrderReposatory => throw new NotImplementedException();



    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
