using CollegeMS.Data;
using CollegeMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CollegeMS.Services
{
    public class CourseRepository : ICourseRepository
    {
        readonly CollegeDB DBContext;
        public CourseRepository(CollegeDB _DBContext)
        {
            DBContext = _DBContext;
        }

        public List<Course> GetAll()
        {
            return DBContext.Courses.ToList();
        }

        public Course GetCourseByInstId(string instId)
        {
            var course = DBContext.Courses.FirstOrDefault(c=>c.InstructorId == instId);
            return course;
        }
        public Course GetById(int id)
        {
            return DBContext.Courses.FirstOrDefault(c => c.Id == id);
        }

        public int Create(Course crs)
        {
            DBContext.Courses.Add(crs);
            int raw = DBContext.SaveChanges();
            return raw;
        }

        public int Update(int id, Course crs)
        {
            Course course = DBContext.Courses.FirstOrDefault(c => c.Id == id);
            course.Name = crs.Name;
            course.Degree = crs.Degree;
            course.MinDegree = crs.MinDegree;
            course.DepId = crs.DepId;
            course.InstructorId = crs.InstructorId;
            int raw = DBContext.SaveChanges();
            return raw;
        }

        public int Delete(int id)
        {
            Course course = DBContext.Courses.FirstOrDefault(c => c.Id == id);
            DBContext.Courses.Remove(course);
            int raw = DBContext.SaveChanges();
            return raw;
        }
        //=====================================================================================
        // get all instructor Courses
        public List<Course> GetAllCourses(string id)
        {
            return DBContext.Courses.Where(ww => ww.InstructorId == id).Include(c=> c.Dep).ToList();
        }

        public string GetInstructorID(int id)
        {
            return DBContext.Courses.FirstOrDefault(ww => ww.Id == id).InstructorId;
        }

        //======================================================================================
        public List<StudentCourses> GetCourses(string id)
        {
            return DBContext.StudentCourses.Where(s => s.StudentId == id).ToList();

        }
    }
}
