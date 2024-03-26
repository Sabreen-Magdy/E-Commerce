namespace AppAssigments.Repository
{
    public class UnitOfWork
    {
        public readonly IStudentRepository studentsRepository;
        public readonly IDepartmentRepository departmentRepository;

        public UnitOfWork(IStudentRepository studentsRepository , IDepartmentRepository departmentRepository)
        {
            this.studentsRepository = studentsRepository;
            this.departmentRepository = departmentRepository;
        }
    }
}
