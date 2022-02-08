using CollegeMS.Data;
using CollegeMS.Models;
using CollegeMS.Services;
using CollegeMS.Services.Repository;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CollegeMS.Validation
{
    public class StudentDegree : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double min, max;
            StudentCourses studentCourses = validationContext.ObjectInstance as StudentCourses;
            var service = (ICourseRepository)validationContext
                    .GetService(typeof(ICourseRepository));
            var course = service.GetById(studentCourses.CourseId);
            min = 0;
            max = course.Degree;
            double degree = value == null ? 0 : (double)value;
            if (degree >= min && degree <= max)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"degree must be between{min} and {max}");
        }

    }
}
