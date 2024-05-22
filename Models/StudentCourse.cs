using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project_eng_ayman.Models
{
    public class StudentCourse
        //third table that make one to many to course and one to many to student
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int CrsId { get; set; }

        public int Degree { get; set; }

        public Course Course { get; set;}

        public Student Student { get; set; }


    }
}
