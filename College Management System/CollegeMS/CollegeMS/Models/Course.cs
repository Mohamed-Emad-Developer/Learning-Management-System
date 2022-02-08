using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeMS.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Course Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Course Degree")]
        
        [Range(0,double.MaxValue)]
        public double Degree { get; set; }


        [Required]

        [Display(Name ="Min Degree")]
        public double MinDegree { get; set; }

        [Required]
        [Display(Name ="Department of course")]
        
        [ForeignKey("Dep")]
        public int? DepId { get; set; }
        public Department Dep { get; set; }

        [Required]

        [Display(Name ="Instructor of course")]
        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
        public Course()
        {
            StudentCourses = new List<StudentCourses>();

        }
    }
}
