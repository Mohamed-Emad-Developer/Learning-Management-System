using CollegeMS.Models;
using CollegeMS.Services;
using CollegeMS.Services.Repository;
using CollegeMS.viewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeMS.Controllers
{
    public class StudentController : Controller
    {
        readonly IStudentRepository StudentRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDepartmentRepository departmentRepository;

        public StudentController(IStudentRepository _StdRepo,
            UserManager<ApplicationUser> _userManager,
            IDepartmentRepository _departmentRepository)
        {
            StudentRepository = _StdRepo;
            userManager = _userManager;
            departmentRepository = _departmentRepository;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Student> student = StudentRepository.GetAll();
            return View(student);
        }

        [Authorize(Roles = "Student")]
        public IActionResult Details(string id)
        {
            Student student = StudentRepository.GetById(id);
            return View(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
           
            ViewData["departments"] = departmentRepository.GetAll();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(StudentVM std)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser NewStudentAccount = new ApplicationUser(); // create new applicationUser to create user name, password
                #region create username password
                NewStudentAccount.UserName = std.Email;
                NewStudentAccount.Email = std.Email;
                NewStudentAccount.Name = std.Name;
                NewStudentAccount.Gender = std.Gender;
                NewStudentAccount.Image = std.Image;
                NewStudentAccount.Age = std.Age;
                NewStudentAccount.Address = std.Address;
                #endregion



                var result = await userManager.CreateAsync(NewStudentAccount, std.Password);
                if (result.Succeeded)
                {
                    var assignResult = await userManager.AddToRoleAsync(NewStudentAccount, "Student");

                    Student student = new Student { Id = NewStudentAccount.Id, DepId = std.DepId, Level = std.Level };// create new instructor to create instructor fields
                    StudentRepository.Create(student);
                    return RedirectToAction("Index");


                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            ViewData["departments"] = departmentRepository.GetAll();


            return View(std);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string id)
        {
            var account = await userManager.FindByIdAsync(id);
            var student = StudentRepository.GetById(id);

            var studentVM = new StudentEditVM
            {
                Name = account.Name,
                Email = account.Email,
                Level = student.Level,
                DepId = student.DepId,
                Id = student.Id,
                Gender = account.Gender,
                Age = account.Age,
                Address = account.Address,
                Image = account.Image,

            };
            ViewData["departments"] = departmentRepository.GetAll();

            return View(studentVM);
           
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] string id, StudentEditVM student)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser account = await userManager.FindByIdAsync(id); 
                Student studentInDB = StudentRepository.GetById(id);

                #region create username password
                account.UserName = student.Email;
                account.Email = student.Email;
                account.Name = student.Name;
                account.Gender = student.Gender;
                account.Age = student.Age;
                account.Address = student.Address;
                account.Image = student.Image;
                #endregion

                studentInDB.Level = student.Level;
                studentInDB.DepId = student.DepId;
                var result = await userManager.UpdateAsync(account);
                if (result.Succeeded)
                {

                    StudentRepository.Update(id, studentInDB);

                    return RedirectToAction("Index");

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            ViewData["departments"] = departmentRepository.GetAll();

            return View(student);
        }
        public IActionResult Delete(string id)
        {
            Student student = StudentRepository.GetById(id);
            return View(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmeDelete(string id)
        {
            StudentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ShowOneStudent(string id)
        {
            Student StudentModel = StudentRepository.GetById(id);
            return View("ShowOneStudent", StudentModel);
        }

        [Authorize(Roles ="Student")]
        public IActionResult GetCourses(string id)
        {
            List<StudentCourses> Crs = StudentRepository.getCrsBystuID(id);
            return PartialView("ShowStudentWithCrs", Crs);
        }
        public IActionResult ShowInfo(string id)
        {
            Student StuModel = StudentRepository.GetById(id);
            return View("ShowInfo", StuModel);
        }

        [Authorize(Roles = "Student")]
        public IActionResult MyCourses(string id)
        {
            var studentCourses = StudentRepository.GetById(id);
            return View(studentCourses.StudentCourses);
        }
    }
}
