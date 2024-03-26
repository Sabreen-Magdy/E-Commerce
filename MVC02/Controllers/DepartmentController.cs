using Microsoft.AspNetCore.Mvc;
using MVC02.Models;
using MVC02.ViewModel;

namespace MVC02.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult create()
        {
            return View();
        }
        [HttpPost] // Specify that this action responds to HTTP POST requests
        public IActionResult AddNewStudent([FromForm] Department department)
        {
            DepartmentList departments = new DepartmentList();
            departments.Add(department);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            DepartmentList departments = new DepartmentList();

            return View(departments.GetDepartments);
        }

        public IActionResult STD_DEPT_Details()
        {
            StudentDepartment std_dept = new StudentDepartment { 
                student = new Student { ID = 1 , Name = "shrouk" , Age = 21 , Email = "Shrouk@gamil.cpm"},
                department = new Department { ID = 3 , Name = "SA"}
            };   
            
            return View(std_dept);
        }
        public IActionResult STD_DEPT_list_Details()
        {
            StudentDepartmentList std_dept_list = new StudentDepartmentList
            {
                students = new List<Student> { new Student { ID = 1, Name = "ROk", Age = 24, Email = "ROk@gmail.com" } },
                departments = new List<Department> { new Department { ID = 3, Name = "SA" } }
            };

            return View(std_dept_list);
        }
    }
}
