using CollegeMS.Models;
using System.Collections.Generic;

namespace CollegeMS.Services.Repository
{
    public interface IStudentCourseRepository
    {
        List<StudentCourses> GetAllbyCourseId(int id);
        public StudentCourses GetByStudCorseId(string id, int Crs_Id);
        public int Edit(StudentCourses EditedSTDC);
        public List<StudentCourses> GetAll();
        public int Create(string studentId, int courseId);
        public int Drop(string studentId, int courseId);
    }
}