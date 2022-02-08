using CollegeMS.Data;
using CollegeMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace CollegeMS.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        readonly CollegeDB DBContext;
        public DepartmentRepository(CollegeDB _DBContext)
        {
            DBContext = _DBContext;
        }

        public List<Department> GetAll()
        {
            return DBContext.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return DBContext.Departments.FirstOrDefault(d => d.Id == id);
        }

        public int Create(Department dept)
        {
            dept.ManagerId = dept.ManagerId == null ? null : dept.ManagerId;
            DBContext.Departments.Add(dept);
            int raw = DBContext.SaveChanges();
            return raw;
        }

        public int Update(int id, Department dept)
        {
            Department department = DBContext.Departments.FirstOrDefault(d => d.Id == id);
            department.Name = dept.Name;
            department.ManagerId = dept.ManagerId;
           
            int raw = DBContext.SaveChanges();
            return raw;
        }

        public int Delete(int id)
        {
            Department department = DBContext.Departments.FirstOrDefault(d => d.Id == id);
            var courses = DBContext.Courses.Where(c => c.DepId == id).ToList();
            foreach (var course in courses)
            {
                course.DepId = null;
            }
            DBContext.Departments.Remove(department);
            int raw = DBContext.SaveChanges();
            return raw;
        }

        public Department GetDepByManager(string mgId)
        {
            return DBContext.Departments.FirstOrDefault(d=> d.ManagerId == mgId);
        }
        public Department GetByName(string name)
        {
            return DBContext.Departments.FirstOrDefault(d=> d.Name == name);
        }
    }
}
