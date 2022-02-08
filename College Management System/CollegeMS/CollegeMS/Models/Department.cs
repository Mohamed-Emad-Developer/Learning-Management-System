using CollegeMS.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeMS.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Departmenr Name")]
        [DepartmentNameCheck]
        [Remote(action: "CheckDeptName",controller:"Error",AdditionalFields ="Id",ErrorMessage ="This Department is already created")]
        public string Name { get; set; }

        [Display(Name="Manager Name")]
        //[Required]
        [ForeignKey("Manager")]
        public string ManagerId { get; set; }
        public Instructor Manager { get; set; }
    }
}
