namespace Domain.Repositories;

/// <summary>
/// Main Repository 
/// </summary>
public interface IAdminRepository
{
    ISallerRepository CustomerRepository { get; }
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IProductCategoryRepository ProductCategoryRepository { get; }
    IProductColerdRepository ProductColerdRepository { get; }
    IProductVarientRepository ProductVarientRepository { get; }
    ISallerRepository SallerRepository { get; }
    IOrderReposatory OrderReposatory { get; }
    


    /// <summary>
    /// Apply Changes in DataBase
    /// </summary>
    /// <returns>number of affected rows</returns>
    int SaveChanges();
}
