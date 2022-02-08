using CollegeMS.Data;
using CollegeMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CollegeMS.Services.Repository
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        CollegeDB DB;
        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;

        public StudentCourseRepository(CollegeDB _DB, IStudentRepository _studentRepository, ICourseRepository _courseRepository)
        {
            DB = _DB;
            studentRepository = _studentRepository;
            courseRepository = _courseRepository;
        }
        public List<StudentCourses> GetAllbyCourseId(int id)
        {
            return DB.StudentCourses.Where(ww => ww.CourseId == id).ToList();
        }
        public StudentCourses GetByStudCorseId(string id,int Crs_Id)
        {
            return DB.StudentCourses.FirstOrDefault(ww=>ww.StudentId==id&&ww.CourseId==Crs_Id);
        }
        public int Edit(StudentCourses EditedSTDC)
        {
            StudentCourses OldSTDC= DB.StudentCourses.FirstOrDefault(ww=>ww.StudentId==EditedSTDC.StudentId&&ww.CourseId==EditedSTDC.CourseId);
            //STDC.Degree = _degree;
            OldSTDC.Degree = EditedSTDC.Degree;
            return DB.SaveChanges();
        }
        public List<StudentCourses> GetAll()
        {
            return DB.StudentCourses.Include(sc=>sc.Course).Include(sc=>sc.Student).ThenInclude(s=>s.User).ToList();
        }
        public int Create(string studentId,int courseId)
        {

            var student = studentRepository.GetById(studentId);
            var course = courseRepository.GetById(courseId);
            var studentCourses = new StudentCourses { CourseId = courseId, StudentId = studentId};
            student.StudentCourses.Add(studentCourses);
            course.StudentCourses.Add(studentCourses);

            return DB.SaveChanges();
        }

        public int Drop(string studentId, int courseId)
        {
            var student = studentRepository.GetById(studentId);
            var course = courseRepository.GetById(courseId);
            var studentCoursesInDB = DB.StudentCourses.FirstOrDefault(sc=>sc.StudentId ==studentId && sc.CourseId == courseId);
            student.StudentCourses.Remove(studentCoursesInDB);
            course.StudentCourses.Remove(studentCoursesInDB);
            return DB.SaveChanges();

        }
    }
}
