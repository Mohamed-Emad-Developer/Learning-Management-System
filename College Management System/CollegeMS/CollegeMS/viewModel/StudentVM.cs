using CollegeMS.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CollegeMS.viewModel
{
    public class StudentVM
    {
 
        [Required]
        [Display(Name = "User Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "User Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public Gender Gender { get; set; }

        public Level Level { get; set; }
        [Display(Name = "Department")]
        public int? DepId { get; set; }
        public int Age { get; set; }
        [Remote(action: "CheckAddress", controller: "Error", ErrorMessage = "Address must be Cairo or Giza")]
        public string Address { get; set; }
        public string Image { get; set; }
    }
}
