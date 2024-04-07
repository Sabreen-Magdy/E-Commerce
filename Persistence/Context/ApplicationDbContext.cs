using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.Entities.Other;
namespace Persistence.Context;

public class ApplicationDbContext: IdentityDbContext<ApplicationIdentityUser>
{
    public ApplicationDbContext(DbContextOptions options)
       : base(options)
    { }
    public DbSet<Saller> Sallers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CartItem> cartItems { get; set; }
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
    public DbSet<Payment> Payments { get; set; }
    public DbSet<ProductVarientBelongToOrder> ProductVarientBelongToOrder { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
       
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);

        // modelBuilder.Entity<IdentityRole>().HasData(InsertData.AddRole());
    }
}
