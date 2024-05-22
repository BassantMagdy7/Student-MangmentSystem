using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project_eng_ayman.Models
{
    //naming convesion (studentid)
    //data annotation
    //fluint api (composite primary key)
    public class Student
    {
        [Key] //primary key

        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        [StringLength(10,MinimumLength =3,ErrorMessage ="Violate StringLength ")]
        [Display(Name="Full Name")]
        public string Name { get; set; }
        [Range(20,30,ErrorMessage ="Range Validator")]
        public int Age { get; set; }
        [Required]
        // [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]{2,4}")]
        [Remote("CheckEmail","student",AdditionalFields ="Name,age")]
        public string Email { get; set; }
        [NotMapped]
        [Compare("Email")]
        public string ConfirmEmail { get; set; }

        [ForeignKey("Department")] //name navigation property
        public int DeptNo { get; set; } 

        //Navigation Property
        public Department Department { get; set; } //student in one department only

        public List<StudentCourse> studentCourses { get; set; }
    }
}
