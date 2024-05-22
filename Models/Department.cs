using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project_eng_ayman.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //ana ale hktbha 
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public bool Status { get; set; } = true;

        public ICollection<Student> Students { get; set; } = new HashSet<Student>(); //not duplicate student in department //department has many students 

        public List<Course> Courses { get; set; }

    }
}
