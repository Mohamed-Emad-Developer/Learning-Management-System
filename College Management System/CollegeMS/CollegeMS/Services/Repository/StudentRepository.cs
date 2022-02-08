using CollegeMS.Data;
using CollegeMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CollegeMS.Services
{
    public class StudentRepository : IStudentRepository
    {
        readonly CollegeDB DBContext;
        public StudentRepository(CollegeDB _DBContext)
        {
            DBContext = _DBContext;
        }

        public List<Student> GetAll()
        {
            return DBContext.Students.Include(s=> s.User).Include(s=>s.Dep).ToList();
        }

        public Student GetById(string id)
        {
            return DBContext.Students.Include(s=>s.User).Include(s=>s.Dep).Include(s=>s.StudentCourses)
                .ThenInclude(s=>s.Course).ThenInclude(c=>c.Instructor).ThenInclude(i=>i.User).FirstOrDefault(s => s.Id == id);
        }

        public int Create(Student std)
        {
            DBContext.Students.Add(std);
            int raw = DBContext.SaveChanges();
            return raw;
        }

        public int Update(string id, Student std)
        {
            Student student = DBContext.Students.FirstOrDefault(s => s.Id == id);
            student.User.Name = std.User.Name;
            student.User.Address = std.User.Address;
            student.User.Gender = std.User.Gender;
            student.User.Age = std.User.Age;
            student.User.Image = std.User.Image;
            student.Level = std.Level;
            student.DepId = std.DepId;
            int raw = DBContext.SaveChanges();
            return raw;
        }

        public int Delete(string id)
        {
            Student student = DBContext.Students.FirstOrDefault(s => s.Id == id);
            DBContext.Students.Remove(student);
            int raw = DBContext.SaveChanges();
            return raw;
        }

        //================================================
        public string getName(string id)
        {
            var student = DBContext.Students.Include(ww => ww.User).FirstOrDefault(ww => ww.Id == id);
            return student.User.Name;
        }
        //=================================================

        public List<Student> getSudentByDeptID(int deptID)
        {
            return DBContext.Students.Include(s=>s.User).Where(s => s.DepId == deptID).ToList();
        }
        public List<StudentCourses> getCrsBystuID(string id)
        {
            return DBContext.StudentCourses.Include(sc=>sc.Course).Where(s => s.StudentId == id).ToList();
        }
        public Student getByName(string Name)
        {
            return DBContext.Students.FirstOrDefault(s => s.User.Name == Name);
        }
    }
}
