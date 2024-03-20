

using Microsoft.EntityFrameworkCore;

namespace Customer.Persistence.Context;

public class CustomerContext: DbContext
{
    public DbSet<Domain.Entities.Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CustomerContext).Assembly);
    }
}
