using System.ComponentModel.DataAnnotations;

namespace CollegeMS.viewModel
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="User Password")]
        public string Password { get; set; }

        [Display(Name ="Remember me")]
        public bool IsPersiste { get; set; }
    }
}
