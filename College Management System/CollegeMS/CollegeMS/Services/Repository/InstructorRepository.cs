using CollegeMS.Data;
using CollegeMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CollegeMS.Services.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        readonly CollegeDB DBContext;
        public InstructorRepository(CollegeDB _DBContext)
        {
            DBContext = _DBContext;
        }

        public List<Instructor> GetAll()
        {
            return DBContext.Instructors.Include(i=> i.User).Include(i=>i.Dep).ToList();
        }

        public Instructor GetById(string id)
        {
            return DBContext.Instructors.FirstOrDefault(i => i.Id == id);
        }

        public int Create(Instructor ins)
        {
            DBContext.Instructors.Add(ins);
            int raw = DBContext.SaveChanges();
            return raw;
        }

        public int Update(string id, Instructor ins)
        {
            Instructor instructor = DBContext.Instructors.FirstOrDefault(i => i.Id == id);
            instructor.User.Name = ins.User.Name;
            instructor.User.Address = ins.User.Address;
            instructor.User.Gender = ins.User.Gender;
            instructor.User.Age = ins.User.Age;
            instructor.User.Image = ins.User.Image;
            instructor.Salary = ins.Salary;
            instructor.DepId = ins.DepId;
            int raw = DBContext.SaveChanges();
            return raw;
        }

        public int Delete(string id)
        {
            Instructor instructor = DBContext.Instructors.FirstOrDefault(i => i.Id == id);
            var course = DBContext.Courses.FirstOrDefault(c=> c.InstructorId == id);
            var department = DBContext.Departments.FirstOrDefault(d => d.ManagerId == id);
            if (course != null)
            {
                course.InstructorId = null;
                 
            }

            if (department != null)
            {
                department.ManagerId = null;
                 
            }
            DBContext.Instructors.Remove(instructor);
            int raw = DBContext.SaveChanges();
            return raw;
        }

        public List<Instructor> GetInsByDeptID(int id)
        {
            return DBContext.Instructors.Where(ww => ww.DepId == id).ToList();
        }
        public List<Instructor> GetInsByDeptIDIncludeUser(int id)
        {
            return DBContext.Instructors.Include(ww => ww.User).Where(ww => ww.DepId == id).ToList();
        }

        
    }
}
