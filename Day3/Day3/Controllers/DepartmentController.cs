using Day3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day3.Controllers
{
    public class DepartmentController : Controller
    {
        DataBContext DB = new DataBContext();
        public IActionResult Index()
        {
            var model = DB.Departments;
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {if (dept != null&&dept?.Name!=null && dept?.Description != null)
            {
                DB.Departments.Add(dept);
                int v = DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dept);
        }
        public IActionResult Edit(int id)
        {   
            if(id==0)
                return BadRequest("enter id to edit");
            var model=DB.Departments.FirstOrDefault(x => x.Id == id);
            if (model != null)
                return View(model);
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            if (dept != null && dept?.Name != null && dept?.Description != null)
            {
                DB.Departments.Update(dept);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dept);
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest("enter id to delete");
            var deleteDept = DB.Departments.FirstOrDefault(x => x.Id == id);
            if (deleteDept != null)
            {   
                DB.Departments.Remove(deleteDept);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }          
            return NotFound();
        }
        
    }
}
