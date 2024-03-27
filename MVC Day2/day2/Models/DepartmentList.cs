namespace day2.Models
{
    public class DepartmentList
    {

        static List<Department> Department = new List<Department>()
        {
                new Department { Id = 1, Name = "IS" },
                new Department { Id = 2, Name = "IT" },
                new Department { Id = 3, Name = "CS" }
        };

        public List<Department> GetAll()
        {
            return Department;
        }
        public void Add(Department dept)
        {
            Department.Add(dept);
        }
    }
}
