using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Project_eng_ayman.Models;
using MVC_Project_eng_ayman.Repository;

namespace MVC_Project_eng_ayman.Controllers
{
    [Authorize(Roles="Admin")]
    public class DepartmentController : Controller
    {

        IDeptRepo departmentrepo; //=new DepartmentRepo();

        public DepartmentController(IDeptRepo _departmentrepo)
        {
            departmentrepo = _departmentrepo;
        }
        public IActionResult Index()
        {
            var model = departmentrepo.GetAll();
            return View(model);
        }

        //add department
        [HttpGet] //action select
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                departmentrepo.Add(model);
                return RedirectToAction("index");
              

            } else
                return View(model);

            // return View("index",db.Departments.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = departmentrepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
                return BadRequest();
           var model= departmentrepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(Department dept,int id)
        {
            dept.DeptId = id;
            departmentrepo.Update(dept);
            return RedirectToAction("index");
        }
        public IActionResult Delete(int? id)
        {
            if(id ==null)
                return BadRequest();
            departmentrepo.Delete(id.Value);
            return RedirectToAction("index");
        }
    }
}
