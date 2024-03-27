using day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    public class StudentDepartment : Controller
    {
        public IActionResult Display()
        {
            Student student = new Student() { Id = 1, Name = "John Doe", age = "20", Address = "123 Main St" };
            Department dept = new Department() { Id = 1, Name = "IS" };
            StudentDepartmentViewModel model = new StudentDepartmentViewModel();
            model.Student = student;
            model.Department = dept;
            return View(model); ;
        }
    }
}
