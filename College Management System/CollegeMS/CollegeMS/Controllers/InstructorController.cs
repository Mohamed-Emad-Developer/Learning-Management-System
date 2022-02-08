using CollegeMS.Data;
using CollegeMS.Enums;
using CollegeMS.Models;
using CollegeMS.Services;
using CollegeMS.Services.Repository;
using CollegeMS.viewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeMS.Controllers
{
    public class InstructorController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IInstructorRepository instructorRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICourseRepository courseRepository;
        private readonly CollegeDB context;
        private readonly IStudentCourseRepository StudentCourseService;
        private readonly IStudentRepository StudentService;

        public InstructorController(UserManager<ApplicationUser> _userManager,
            IInstructorRepository _instructorRepository,
            IDepartmentRepository _departmentRepository, ICourseRepository _courseRepository,
            CollegeDB _context, IStudentCourseRepository _studentCourseRepository, IStudentRepository _StudentService)
        {

            userManager = _userManager;
            instructorRepository = _instructorRepository;
            departmentRepository = _departmentRepository;
            courseRepository = _courseRepository;
            context = _context;
            StudentCourseService = _studentCourseRepository;
            StudentService = _StudentService;
        }
        [Authorize(Roles = "Instructor")]
        public IActionResult Details(string id)
        {
            var courses = courseRepository.GetAllCourses(id);
            ViewBag.Departments = courseRepository.GetAll();
            ViewBag.Studcourses = StudentCourseService.GetAll();
            ViewBag.instructors = instructorRepository.GetAll();
            ViewData["InstructorID"] = id;
            return View(courses);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var instructors = instructorRepository.GetAll();
            return View(instructors);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["departments"] = departmentRepository.GetAll();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(InstructorVM instructorVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser instructorNewAccount = new ApplicationUser(); // create new applicationUser to create user name, password
                #region create username password
                instructorNewAccount.UserName = instructorVM.Email;
                instructorNewAccount.Email = instructorVM.Email;
                instructorNewAccount.Name = instructorVM.Name;
                instructorNewAccount.Gender = instructorVM.Gender;
                instructorNewAccount.Age = instructorVM.Age;
                instructorNewAccount.Address = instructorVM.Address;
                instructorNewAccount.Image = instructorVM.Image;
                #endregion



                var result = await userManager.CreateAsync(instructorNewAccount, instructorVM.Password);
                if (result.Succeeded)
                {
                    // assign application user (instructorUser) to role name = "Instructor"
                    var assignResult = await userManager.AddToRoleAsync(instructorNewAccount, "Instructor");

                    Instructor instructor = new Instructor { Id = instructorNewAccount.Id, DepId = instructorVM.DepId, Salary = instructorVM.Salary };// create new instructor to create instructor fields
                    instructorRepository.Create(instructor);
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

            return View(instructorVM);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            var account = await userManager.FindByIdAsync(id);
            var instructor = instructorRepository.GetById(id);

            var instructorVM = new InstructorEditVM
            {
                Name = account.Name,
                Email = account.Email,
                Salary = instructor.Salary,
                DepId = instructor.DepId,
                Id = instructor.Id,
                Gender = account.Gender,
                Age = account.Age,
                Address = account.Address,
                Image = account.Image,

            };
            ViewData["departments"] = departmentRepository.GetAll();

            return View(instructorVM);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] string id, InstructorEditVM instructor)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser account = await userManager.FindByIdAsync(id);
                Instructor instructorInDB = instructorRepository.GetById(id);

                #region create username password
                account.UserName = instructor.Email;
                account.Email = instructor.Email;
                account.Name = instructor.Name;
                account.Gender = instructor.Gender;
                account.Age = instructor.Age;
                account.Address = instructor.Address;
                account.Image = instructor.Image;
                #endregion

                instructorInDB.Salary = instructor.Salary;
                instructorInDB.DepId = instructor.DepId;
                var result = await userManager.UpdateAsync(account);
                if (result.Succeeded)
                {

                    instructorRepository.Update(id, instructorInDB);

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

            return View(instructor);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var account = await userManager.FindByIdAsync(id);
            if (account == null)
                return NotFound();
            
            instructorRepository.Delete(id);

            var result = await userManager.DeleteAsync(account);
            if (result.Succeeded)
            {

                return RedirectToAction("Index");
            }
            return NotFound(account);
        }

        [Authorize(Roles = "Instructor")]
        public IActionResult Show(int id)
        {
            var sc = StudentCourseService.GetAllbyCourseId(id);
            string INS_ID = courseRepository.GetInstructorID(id);
            ViewData["InstructorID"] = INS_ID;
            List<StudentCourseModel> Stdc = new List<StudentCourseModel>();
            foreach (var item in sc)
            {
                Stdc.Add(new StudentCourseModel()
                {
                    ID = item.StudentId,
                    Name = StudentService.getName(item.StudentId),
                    Level = StudentService.GetById(item.StudentId).Level,
                    degree = (double?)item.Degree,
                    Crs_ID = id
                });
            }
            return View(Stdc);
        }

        [Authorize(Roles = "Instructor")]
        public IActionResult SetDegree(string id, int Crs_ID)
        {
            StudentCourses STDC = StudentCourseService.GetByStudCorseId(id, Crs_ID);
            return View(STDC);
        }
        [Authorize(Roles = "Instructor")]
        public IActionResult SaveDegree(StudentCourses EditedSTDC)
        {
            if (ModelState.IsValid == true)
            {
                StudentCourseService.Edit(EditedSTDC);
                return RedirectToAction("Show", new { id = EditedSTDC.CourseId });

            }
            else
                //  return RedirectToAction("SetDegree", new { id = EditedSTDC.StudentId, Crs_ID=EditedSTDC.CourseId });
                return View("SetDegree", EditedSTDC);
        }
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> InstructorInfo(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            InstructorInfoViewModel InsInfo = new InstructorInfoViewModel();
            InsInfo.id = id;
            InsInfo.Name = user.Name;
            InsInfo.Address = user.Address;
            InsInfo.Email = user.Email;
            InsInfo.Gender = user.Gender;
            InsInfo.Age = user.Age;
            InsInfo.Image = user.Image;
            return View(InsInfo);
        }
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> EditInstructorInfo(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            InstructorInfoViewModel InsInfo = new InstructorInfoViewModel();
            InsInfo.id = id;
            InsInfo.Name = user.Name;
            InsInfo.Address = user.Address;
            InsInfo.Email = user.Email;
            InsInfo.Gender = user.Gender;
            InsInfo.Age = user.Age;
            InsInfo.Image = user.Image;
            return View(InsInfo);
        }

        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> EditInstructorInfo([FromRoute] string id, InstructorInfoViewModel EditedIns)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByIdAsync(id);
                user.Name = EditedIns.Name;
                user.Address = EditedIns.Address;
                user.Email = EditedIns.Email;
                user.Gender = EditedIns.Gender;
                user.Age = EditedIns.Age;
                user.Image = EditedIns.Image;
                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("InstructorInfo", new { id = user.Id });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(EditedIns);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult getInstructor(int id)
        {

            List<Instructor> instructors = instructorRepository.GetInsByDeptIDIncludeUser(id);
            return PartialView("_AllInstructors", instructors);
        }
    }
}
