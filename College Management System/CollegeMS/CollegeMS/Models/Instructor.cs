using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeMS.Models
{
    public class Instructor
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }

        [MaxLength(100)]
        public decimal Salary { get; set; }

        [Display(Name ="Department of instructor")]
        [ForeignKey("Dep")]
        public int? DepId { get; set; }
        public Department Dep { get; set; }
    }
}
