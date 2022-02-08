using CollegeMS.Models;
using CollegeMS.Services;
using CollegeMS.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CollegeMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        readonly ICourseRepository CourseRepository;
        readonly IDepartmentRepository DepartmentRepository;
        readonly IInstructorRepository InstructorRepository;

        public CourseController(ICourseRepository _CrsRepo, IDepartmentRepository _DeptRepo, IInstructorRepository _InsRepo )
        {
            CourseRepository = _CrsRepo;
            DepartmentRepository = _DeptRepo;
            InstructorRepository = _InsRepo;
        }

        public IActionResult Index()
        {
            List<Course> course = CourseRepository.GetAll();
            List<Department> departments = DepartmentRepository.GetAll();
            ViewData["Departments"] = departments;
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(course);
        }

        public IActionResult Details(int id)
        {
            Course course = CourseRepository.GetById(id);
            List<Department> departments = DepartmentRepository.GetAll();
            ViewData["Departments"] = departments;
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(course);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            List<Department> departments = DepartmentRepository.GetAll();
            ViewData["Departments"] = departments;
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course crs)
        {
            if (ModelState.IsValid == true)
            {
                CourseRepository.Create(crs);
                return RedirectToAction("Index");
            }
            List<Department> departments = DepartmentRepository.GetAll();
            ViewData["Departments"] = departments;
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(crs);
        }

        public IActionResult Update(int id)
        {
            Course course = CourseRepository.GetById(id);
            List<Department> departments = DepartmentRepository.GetAll();
            ViewData["Departments"] = departments;
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(course);
        }

        [HttpPost]
        public IActionResult Update([FromRoute] int id, Course crs)
        {
            if (ModelState.IsValid == true)
            {
                CourseRepository.Update(id, crs);
                return RedirectToAction("Index");
            }
            List<Department> departments = DepartmentRepository.GetAll();
            ViewData["Departments"] = departments;
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(crs);
        }

        public IActionResult Delete(int id)
        {
            Course course = CourseRepository.GetById(id);
            List<Department> departments = DepartmentRepository.GetAll();
            ViewData["Departments"] = departments;
            List<Instructor> instructors = InstructorRepository.GetAll();
            ViewData["Instructors"] = instructors;
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmeDelete(int id)
        {
            CourseRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
