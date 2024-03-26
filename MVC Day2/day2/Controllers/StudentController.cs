using day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    public class StudentController : Controller
    {

        public IActionResult Index()
        {
            StudentList std = new StudentList();
            List<Student> model = std.GetAll();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Add(Student std)
        {
            StudentList sd = new StudentList();
            sd.Add(std);
            return RedirectToAction("Index");
        }
        public IActionResult Display()
        {
            Student student = new Student() { Id = 1, Name = "Naira", age = "20", Address = "123 Main St" };
            return View(student); ;
        }
    }
}
