using CollegeMS.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeMS.Models
{
    public class StudentCourses
    {
        [Display(Name ="Student Name")]
        [ForeignKey("Student")]
        public string StudentId { get; set; }

        [Display(Name ="Course Name")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

        [StudentDegree]
        public double? Degree { get; set; }
    }
}
