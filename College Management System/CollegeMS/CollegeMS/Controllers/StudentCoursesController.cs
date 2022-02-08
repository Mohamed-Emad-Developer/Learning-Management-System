using CollegeMS.Models;
using CollegeMS.Services;
using CollegeMS.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CollegeMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentCoursesController : Controller
    {

        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IStudentCourseRepository studentCourseRepository;

        public StudentCoursesController(IStudentRepository _studentRepository, ICourseRepository _courseRepository,
            IStudentCourseRepository _studentCourseRepository)
        {
            studentRepository = _studentRepository;
            courseRepository = _courseRepository;
            studentCourseRepository = _studentCourseRepository;
        }
        public IActionResult Index()
        {
            var studentCourses = studentCourseRepository.GetAll();
            return View(studentCourses);
        }

        public IActionResult Create()
        {
            ViewData["Students"] = studentRepository.GetAll();
            ViewData["Courses"] = courseRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCourses studentCourses)
        {
            if (ModelState.IsValid)
            {
                var studentCoursesInDB =
                    studentCourseRepository.GetAll().Where(sc => sc.StudentId == studentCourses.StudentId && sc.CourseId == studentCourses.CourseId);
                if (studentCoursesInDB.Count() > 0)
                {
                    ModelState.AddModelError("", "this student is already in this course");
                    ViewData["Students"] = studentRepository.GetAll();
                    ViewData["Courses"] = courseRepository.GetAll();
                    return View(studentCourses);
                }
                studentCourseRepository.Create(studentCourses.StudentId, studentCourses.CourseId);
                return RedirectToAction("Index");
            }
            ViewData["Students"] = studentRepository.GetAll();
            ViewData["Courses"] = courseRepository.GetAll();
            return View(studentCourses);
        }

        public IActionResult Drop([FromRoute]string studentId, [FromRoute]int courseId)
        {
            if(studentId != null && courseId !=0)
            {
                studentCourseRepository.Drop(studentId, courseId);
                return RedirectToAction("Index");
            } 

            return NotFound();
        }
    }
}
