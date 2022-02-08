using CollegeMS.Enums;
using CollegeMS.Services.Repository;
using CollegeMS.Validation;
namespace CollegeMS.viewModel
{
    public class StudentCourseModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; }
        [StudentDegree]
        public double? degree { get; set; }
        //course ID
        public int Crs_ID { get; set; }
    }
}
