using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext: DbContext
{
    public DbSet<Domain.Entities.Customer> Customers { get; set; }
    public DbSet<Domain.Entities.Order> Orders { get; set; }
    //public DbSet<Domain.Entities.ProductVarientBelongToOrder> ProductVarientBelongToOrders { get; set; }
    //public DbSet<Domain.Entities.ColoredProduct> ColoredProducts { get; set; }
    //public DbSet<Domain.Entities.Size> Sizes { get; set; }
    public ApplicationDbContext(DbContextOptions options)
       : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }
}
