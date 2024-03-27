using AppAssigments.Models;

namespace AppAssigments.Repository
{
    public class StudentsRepository:GeneralRepository<Student> , IStudentRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

     
    }
}
