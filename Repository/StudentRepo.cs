using Microsoft.EntityFrameworkCore;
using MVC_Project_eng_ayman.Models;

namespace MVC_Project_eng_ayman.Repository
{
      public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add (Student student);
        void Update(Student student);
        void Delete(int id);
    }
    public class StudentRepo:IStudentRepo
    {
        ITIContext db;  //= new ITIContext();

        public StudentRepo(ITIContext _db)
        {
            db = _db;
        }
        public List<Student> GetAll()
        {
            return db.Students.Include(s=>s.Department).ToList();
        }
        public Student GetById(int id)
        {
            return db.Students.Include(s=>s.Department).SingleOrDefault(s => s.Id == id);

        }
        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
           var s= db.Students.FirstOrDefault(s => s.Id == id);
            db.Students.Remove(s);
            db.SaveChanges();
        }
    }
}
