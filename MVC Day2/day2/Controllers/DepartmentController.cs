using day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            DepartmentList db = new DepartmentList();
            List<Department> model = db.GetAll();

            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Add(Department dept) 
        {
            DepartmentList db = new DepartmentList();
            db.Add(dept);
            return RedirectToAction("Index");
        }
        public IActionResult Display()
        {
            Department dept = new Department() { Id = 1, Name = "IS" };
            return View(dept); ;
        }
    }
}
