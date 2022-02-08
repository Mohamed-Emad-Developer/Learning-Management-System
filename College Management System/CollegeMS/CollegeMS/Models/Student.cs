using CollegeMS.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeMS.Models
{
    public class Student
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }
        public Level Level { get; set; }
        public ApplicationUser User { get; set; }
        [Display(Name = "Department of student")]
        [ForeignKey("Dep")]
        public int? DepId { get; set; }
        public Department Dep { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
        public Student()
        {
            StudentCourses = new List<StudentCourses>();

        }
    }
}
