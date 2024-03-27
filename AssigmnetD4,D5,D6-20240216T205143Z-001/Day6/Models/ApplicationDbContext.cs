using Microsoft.EntityFrameworkCore;

namespace AppAssigments.Models
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().
            UseSqlServer(
                   "Data Source=.;Initial Catalog=temp1;Integrated Security=True");

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments {  get; set; }
    }
}
