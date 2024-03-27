using AppAssigments.Models;

namespace AppAssigments.Repository
{
    public class DepartmentRepository:GeneralRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public DepartmentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
