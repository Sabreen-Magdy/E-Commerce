using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Persistence.Context;

public class ApplicationDbContext: DbContext
{
    public DbSet<Saller> Sallers
    { get; set; }
    public DbSet<Domain.Entities.Customer> Customers { get; set; }
    public DbSet<Domain.Entities.Cart> Carts { get; set; }
    public DbSet<Domain.Entities.Favourite> Favourites { get; set; }
    public DbSet<Domain.Entities.Review> Reviews { get; set; }


    public DbSet<Product> Products { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<ColoredProduct> ColoredProducts { get; set; }
    public DbSet<ProductVarient> ProductVarients { get; set; }
    public DbSet<Order> Orders { get; set; }
    //public DbSet<Category> Categories { get; set; }
    //public DbSet<ProductCategory> ProductCategories { get; set; }

    public ApplicationDbContext(DbContextOptions options)
       : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }
}
