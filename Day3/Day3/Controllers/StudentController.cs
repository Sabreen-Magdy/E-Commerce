using Day3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day3.Controllers
{
    public class StudentController : Controller
    {
        DataBContext DB=new DataBContext();
        public IActionResult Index()
        {
            var model = DB.Students.Include(s=>s.Department);
            return View(model);
        }
    }
}
