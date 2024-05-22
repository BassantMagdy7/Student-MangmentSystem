using Microsoft.EntityFrameworkCore;

namespace MVC_Project_eng_ayman.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Student> Students { get; set; }    
        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ITIContext()
        {
            
        }
        public ITIContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=temp;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<StudentCourse>().HasKey(c=> new { c.StudentId, c.CrsId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
