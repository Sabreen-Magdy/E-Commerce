using MVC02.Models;

namespace MVC02.ViewModel
{
    public class StudentDepartmentList
    {
       
        public List<Student> students { get; set; }
        //public StudentList students { get; set; }
        public List<Department> departments { get; set; }
        //public DepartmentList departments { get; set; }
    }
}
