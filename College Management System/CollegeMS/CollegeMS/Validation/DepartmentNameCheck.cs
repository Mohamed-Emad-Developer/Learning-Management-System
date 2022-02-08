using CollegeMS.Data;
using CollegeMS.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CollegeMS.Validation
{
    public class DepartmentNameCheck : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = validationContext.GetService(typeof(CollegeDB)) as CollegeDB;
            var departmentInModel = validationContext.ObjectInstance as Department;
            var name = (string)value;
            var depExist = context.Departments.ToList().Any(d => d.Name.ToLower() == name.ToLower());
            var departmentInDB = context.Departments.FirstOrDefault(d => d.Name.ToLower() == name.ToLower());
            if (departmentInModel.Id == 0)
            {
                if (!depExist)

                    return ValidationResult.Success;
                else
                    return new ValidationResult("This Department was already Created..");

            }
            else
            {
                if (!depExist)

                    return ValidationResult.Success;
                else
                {
                    if (departmentInModel.Id == departmentInDB.Id)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult("This Department was already Created..");
                }
            }



        }
    }
}
