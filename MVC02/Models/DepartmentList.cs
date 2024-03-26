namespace MVC02.Models
{
    public class DepartmentList
    {
        static List<Department> departments = new List<Department>()
        {
            new Department {ID = 1, Name ="SD"},

            new Department {ID = 2, Name ="OS"},

            new Department {ID = 3, Name ="EL"},

        };

        public List<Department> GetDepartments { get { return departments; } }

        public void Add(Department dept)
        {
            departments.Add(dept);
        }
    }
}
