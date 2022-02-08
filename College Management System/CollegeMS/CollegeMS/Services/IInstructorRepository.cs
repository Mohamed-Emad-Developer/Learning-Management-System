using CollegeMS.Models;
using System.Collections.Generic;

namespace CollegeMS.Services.Repository
{
    public interface IInstructorRepository
    {
        int Create(Instructor ins);
        int Delete(string id);
        List<Instructor> GetAll();
        Instructor GetById(string id);
        int Update(string id, Instructor ins);
        public List<Instructor> GetInsByDeptID(int id);
        public List<Instructor> GetInsByDeptIDIncludeUser(int id);
    }
}