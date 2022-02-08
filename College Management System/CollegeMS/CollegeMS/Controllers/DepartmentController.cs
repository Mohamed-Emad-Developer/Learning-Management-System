using CollegeMS.Models;
using CollegeMS.Services;
using CollegeMS.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CollegeMS.Controllers
{
   
    public class DepartmentController : Controller
    {
        readonly IDepartmentRepository DepartmentRepository;
        readonly IInstructorRepository InstructorRepository;
        private readonly IStudentRepository studentRepository;

        public DepartmentController(IDepartmentRepository _DeptRepo, IInstructorRepository _InsRepo,IStudentRepository _studentRepository)
        {
            DepartmentRepository = _DeptRepo;
            InstructorRepository = _InsRepo;
            studentRepository = _studentRepository;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Department> department = DepartmentRepository.GetAll();
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(department);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            Department department = DepartmentRepository.GetById(id);
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(department);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
          
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View();
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {
                var managerExist = DepartmentRepository.GetAll().Any(d=>d.ManagerId == dept.ManagerId);
                if (managerExist)
                {
                    ModelState.AddModelError("", "This Instructor is a manager to another department");
                }
                else
                {
                    DepartmentRepository.Create(dept);
                    return RedirectToAction("Index");
                }
              

            }
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(dept);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            Department department = DepartmentRepository.GetById(id);
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(department);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update([FromRoute] int id, Department dept)
        {
            if (ModelState.IsValid)
            {
                DepartmentRepository.Update(id, dept);
                return RedirectToAction("Index");
            }
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(dept);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Department department = DepartmentRepository.GetById(id);
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(department);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmeDelete(int id)
        {
            DepartmentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult GetStudentByID(int DeptID)
        {
            List<Student> students = studentRepository.getSudentByDeptID(DeptID);
            return PartialView("ShowStudentWithDept", students);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ShowAllDepartment()
        {
            List<Department> DeptModel = DepartmentRepository.GetAll();
            return View("ShowAllDepartment", DeptModel);
        }
    }
}
