using CollegeMS.Models;
using System.Collections.Generic;

namespace CollegeMS.Services
{
    public interface IStudentRepository
    {
        int Create(Student std);
        int Delete(string id);
        List<Student> GetAll();
        Student GetById(string id);
        int Update(string id, Student std);
        public string getName(string id);
        Student getByName(string Name);
        List<StudentCourses> getCrsBystuID(string id);
        List<Student> getSudentByDeptID(int deptID);
    }
}