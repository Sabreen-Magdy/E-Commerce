using AppAssigments.Models;
using AppAssigments.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppAssigments.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public StudentsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Student> students = unitOfWork.studentsRepository.GetAll().ToList(); //unitOfWork.studentsRepository.GetAll().Include(x => x.Department).ToList();

            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Student student = new Student();

            List<SelectListItem> departmentsSelectList = unitOfWork.departmentRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = Convert.ToString(x.Id)
            }).ToList();

            ViewBag.Departments = departmentsSelectList;

            return View(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.studentsRepository.Add(student);
                return RedirectToAction(nameof(Index));

            }
            else
            {
                List<SelectListItem> departmentsSelectList2 = unitOfWork.departmentRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = Convert.ToString(x.Id)
                }).ToList();

                ViewBag.Departments = departmentsSelectList2;
                return View(student);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if(id != 0)
            {
                Student student = unitOfWork.studentsRepository.GetBySingelId(id);

                List<SelectListItem> departmentsSelectList = unitOfWork.departmentRepository.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = Convert.ToString(x.Id)
                }).ToList();

                ViewBag.Departments = departmentsSelectList;

                return View(student);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Update(int id , Student student)
        {
            if(id == student.Id)
            {
                if (ModelState.IsValid)
                {

                    try
                    {
                        Student model = unitOfWork.studentsRepository.GetBySingelId(student.Id);

                        model.Name = student.Name;
                        model.Address = student.Address;
                        model.Age = student.Age;
                        model.DepartmentId = student.DepartmentId;

                        unitOfWork.studentsRepository.Update(model);
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);

                        List<SelectListItem> departmentsSelectList2 = unitOfWork.departmentRepository.GetAll().Select(x => new SelectListItem
                        {
                            Text = x.Name,
                            Value = Convert.ToString(x.Id)
                        }).ToList();

                        ViewBag.Departments = departmentsSelectList2;

                        return View(student);

                    }

                }
                else
                {

                    List<SelectListItem> departmentsSelectList2 = unitOfWork.departmentRepository.GetAll().Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = Convert.ToString(x.Id)
                    }).ToList();

                    ViewBag.Departments = departmentsSelectList2;

                    return View(student);

                }

            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                Student student = unitOfWork.studentsRepository.GetBySingelId(id);
                
                if (student != null)
                {
                    unitOfWork.studentsRepository.Delete(student);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }


        public IActionResult IsUsernameExisted(string name , int id)
        {
            var isExisted = unitOfWork.studentsRepository.GetAll().FirstOrDefault(x => x.Name == name);
            bool isValid = (isExisted == null) || (isExisted.Id == id);

            return Json(isValid);
        }
    }

}
