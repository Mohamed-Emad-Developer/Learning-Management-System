using CollegeMS.Models;
using System.Collections.Generic;

namespace CollegeMS.Services
{
    public interface IDepartmentRepository
    {
        int Create(Department dept);
        int Delete(int id);
        List<Department> GetAll();
        Department GetById(int id);
        Department GetByName(string name);
        int Update(int id, Department dept);
        Department GetDepByManager(string mgId);
    }
}