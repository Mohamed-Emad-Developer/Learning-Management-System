using CollegeMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CollegeMS.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        public ErrorController(IDepartmentRepository _departmentRepository)
        {
            departmentRepository = _departmentRepository;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult CheckAddress(string address)
        {
            if (address.ToLower() == "cairo" || address.ToLower() == "giza")
                return Json(true);
            else
                return Json(false);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult CheckDeptName(string name, int id)
        {
            var depExist = departmentRepository.GetAll().Any(d => d.Name.ToLower() == name.ToLower());
            var departmentInDB = departmentRepository.GetByName(name);
            if (id == 0)
            {
                if (!depExist)
                    return Json(true);
                else
                    return Json(false);
            }
            else
            {
                if (!depExist)
                    return Json(true);
                else
                {

                    if (departmentInDB.Id == id)
                        return Json(true);
                    else
                        return Json(false);

                }

            }
        }
    }
}
