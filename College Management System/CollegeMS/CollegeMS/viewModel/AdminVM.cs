using System.ComponentModel.DataAnnotations;

namespace CollegeMS.viewModel
{
    public class AdminVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Name")]
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
    }
}
