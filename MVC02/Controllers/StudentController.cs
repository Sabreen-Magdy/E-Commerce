using Microsoft.AspNetCore.Mvc;
using MVC02.Models;

namespace MVC02.Controllers
{
    public class StudentController : Controller
    {

        public IActionResult create()
        {
            return View();
        }
        [HttpPost] // Specify that this action responds to HTTP POST requests
        public IActionResult AddNewStudent([FromForm]Student student)
        {
            StudentList students = new StudentList();
            students.Add(student);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            StudentList students = new StudentList();

            return View(students.GetStudents);
        }
    }
}
