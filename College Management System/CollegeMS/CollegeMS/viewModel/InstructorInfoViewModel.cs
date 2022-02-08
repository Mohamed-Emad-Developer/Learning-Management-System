using CollegeMS.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CollegeMS.viewModel
{
    public class InstructorInfoViewModel
    {
        public string id { get; set; }  
        [Required(ErrorMessage = "name is required.")]
        [RegularExpression("^[a-zA-Z_ ]*$", ErrorMessage = "name contains char, spaces only ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Adrress is required.")]
        [RegularExpression(pattern: "^[a-zA-Z0-9_ ]*$", ErrorMessage = "Address conatains char,Numbers,spaces")]
        [Remote(action: "CheckAddress", controller: "Error", ErrorMessage = "Address must be Cairo or Giza")]
        public string Address { get; set; }
        [Required]
        public Gender Gender { get; set;}
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Age")]
        [Range(20, 60, ErrorMessage = "Age Should be min 20 and max 60")]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"\w+\.(jpg|png)", ErrorMessage = "Image must contain jpg or png ")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }


    }
}
