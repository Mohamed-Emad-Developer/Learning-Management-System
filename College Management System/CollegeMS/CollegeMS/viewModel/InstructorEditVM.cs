using CollegeMS.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CollegeMS.viewModel
{
    public class InstructorEditVM
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Email")]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        [Display(Name ="Department")]
        public int? DepId { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        [Remote(action: "CheckAddress", controller: "Error",ErrorMessage ="Address must be Cairo or Giza")]
        public string Address { get; set; }
        public string Image { get; set; }
    }
}
