using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project_eng_ayman.Models;

namespace MVC_Project_eng_ayman.Controllers
{
    public class DepartmentCourseController : Controller
    { 
        ITIContext db = new ITIContext();
        public IActionResult showcourses(int id)
        {
            var model= db.Departments.Include(a=>a.Courses).FirstOrDefault(a=>a.DeptId==id);
            return View(model);
        }
        public IActionResult MangeCourse(int id)
        {
            var model = db.Departments.Include(a => a.Courses).FirstOrDefault(a => a.DeptId == id);
            var allcourses =db.Courses.ToList();
            var coursesindept = model.Courses;
            var coursesnotindept =allcourses.Except(coursesindept).ToList();
            ViewBag.coursenotindept =coursesnotindept;
            return View(model);
        }
        [HttpPost]
        public IActionResult MangeCourse(int id ,List<int> coursestoremove,List<int> coursestoadd)
        {
            Department dept = db.Departments.Include(a=>a.Courses).FirstOrDefault(a => a.DeptId == id);
            foreach(var item in coursestoremove)
            {
                Course c = db.Courses.FirstOrDefault(a => a.Id == item);
                dept.Courses.Remove(c);
            }
            db.SaveChanges();
            foreach (var item in coursestoadd)
            {
                Course c = db.Courses.FirstOrDefault(a => a.Id == item);
                dept.Courses.Add(c);
            }
            db.SaveChanges();
            return RedirectToAction("Index","Department");
        }

        public IActionResult addstudentdegree(int deptid ,int crsId)
        {
           var student= db.Students.Where(a => a.DeptNo == deptid).ToList();
            ViewBag.students = student;
            Department dept = db.Departments.Include(a => a.Students).FirstOrDefault(a => a.DeptId == deptid);
            Course course=db.Courses.FirstOrDefault(a=>a.Id == crsId);
            ViewBag.course = course;
            return View(dept);

        }
        [HttpPost]
        public IActionResult addstudentdegree(int deptid, int crsId,Dictionary<int,int>degree)
        {
            
            foreach(var item in degree)
            {
               var stdcrs= db.StudentCourses.FirstOrDefault(a => a.StudentId == item.Key && a.CrsId == crsId);
                if(stdcrs == null)
                { 
                    StudentCourse studentcourse = new StudentCourse() { StudentId = item.Key, CrsId = crsId, Degree = item.Value };

                   db.StudentCourses.Add(studentcourse);

                }
                else
                { 
                    stdcrs.Degree = item.Value;

                }
              
               
            }
            db.SaveChanges();
            return RedirectToAction("index", "department");

        }

    }
}
