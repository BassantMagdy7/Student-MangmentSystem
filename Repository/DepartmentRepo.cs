using Microsoft.EntityFrameworkCore;
using MVC_Project_eng_ayman.Models;

namespace MVC_Project_eng_ayman.Repository
{
    public interface IDeptRepo
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Add(Department d);
        void Update(Department d);
        void Delete(int id);
    }
    public class DepartmentRepo:IDeptRepo
    {
        ITIContext db;//= new ITIContext();

        public DepartmentRepo(ITIContext _db)
        {
            db = _db;
        }
        public List<Department> GetAll()
        {
            Console.WriteLine("departmentlist required");
            return db.Departments.Where(a=>a.Status==true).ToList();
        }
        public Department GetById(int id)
        {
            return db.Departments.SingleOrDefault(a => a.DeptId == id);
        }
        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var dept =GetById(id);
            dept.Status = false;
            db.SaveChanges();
        }

    }
}
