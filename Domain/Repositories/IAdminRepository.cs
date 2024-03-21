namespace Domain.Repositories;

/// <summary>
/// Main Repository 
/// </summary>
public interface IAdminRepository
{
    ICustomerRepository CustomerRepository { get; }
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IProductCategoryRepository ProductCategoryRepository { get; }
    IProductColerdRepository ProductColerdRepository { get; }
    IProductVarientRepository ProductVarientRepository { get; }

    /// <summary>
    /// Apply Changes in DataBase
    /// </summary>
    /// <returns>number of affected rows</returns>
    int SaveChanges();
}
