using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Persistence.Context;

public class ApplicationDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Saller> Sallers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Favourite> Favourites { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<ColoredProduct> ColoredProducts { get; set; }
    public DbSet<ProductVarient> ProductVarients { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ProductVarientBelongToOrder> ProductVarientBelongToOrder { get; set; }
    //public DbSet<Category> Categories { get; set; }
    //public DbSet<ProductCategory> ProductCategories { get; set; }

    public ApplicationDbContext(DbContextOptions options)
       : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    //    modelBuilder.Entity<ProductVarient>()
    //.HasOne(pv => pv.ColoredProduct)
    //.WithMany(cp => cp.Varients)
    //.HasForeignKey(pv => pv.ColoredProductId);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }
}
