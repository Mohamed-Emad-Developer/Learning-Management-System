using CollegeMS.Models;
using System.Collections.Generic;

namespace CollegeMS.Services
{
    public interface ICourseRepository
    {
        int Create(Course Crs);
        int Delete(int id);
        List<Course> GetAll();
        Course GetById(int id);
        int Update(int id, Course Crs);
        List<Course> GetAllCourses(string id);
        public string GetInstructorID(int id);
        List<StudentCourses> GetCourses(string id);
        public Course GetCourseByInstId(string instId);

    }
}