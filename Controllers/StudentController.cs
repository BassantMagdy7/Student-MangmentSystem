using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project_eng_ayman.Models;
using MVC_Project_eng_ayman.Repository;

namespace MVC_Project_eng_ayman.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        ITIContext db = new ITIContext();
        IDeptRepo departmentRepo; //= new DepartmentRepo();
        IStudentRepo studentRepo; //= new StudentRepo();

        public StudentController(IDeptRepo _departmentRepo,IStudentRepo _studentRepo)
        {
            departmentRepo = _departmentRepo;
            studentRepo = _studentRepo;
        }

        public IActionResult Index()
        {
            var model = studentRepo.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.deptlist=  departmentRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student std) 
        {
            //statemodel
            if (ModelState.IsValid)
            { 
             studentRepo.Add(std);
            return RedirectToAction("Index");
            }

            ViewBag.deptlist = departmentRepo.GetAll();
                return View(std);
            
        }
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();

            }
            var model = studentRepo.GetById(id.Value);
            if(model==null)
            {
                return NotFound();
                
            }
            return View(model);
        }
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();

            }
            var model = studentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();

            }
            ViewBag.deptlist = departmentRepo.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Student std)
        {
            studentRepo.Update(std);
            return RedirectToAction("Index");
        }
        public IActionResult details2(int id) 
        {
           var model=  studentRepo.GetById(id);
            return PartialView(model);
        }
        public IActionResult CheckEmail(string Email,string Name,int age)
        {
           var model= db.Students.FirstOrDefault(a=>a.Email== Email);
            if (model != null)
                return Json($"{Name}+{age}@iti.com");
            else
                return Json(true);
        }
    }
}
