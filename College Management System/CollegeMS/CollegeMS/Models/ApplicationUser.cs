using CollegeMS.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CollegeMS.Models
{
    public class ApplicationUser: IdentityUser
    {
        //characters
        public string Name { get; set; }
        [Remote(action: "CheckAddress", controller: "Error", ErrorMessage = "Address must be Cairo or Giza")]
        public string Address { get; set; }
        public Gender Gender { get; set; }
        [Range(18,60)]
        public int Age { get; set; }
        public string Image { get; set; }

    }
}
