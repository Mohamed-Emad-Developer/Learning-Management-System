using CollegeMS.Data;
using CollegeMS.Models;
using CollegeMS.viewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly CollegeDB context;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(SignInManager<ApplicationUser> _signInManager,
            UserManager<ApplicationUser> _userManager, CollegeDB _context,RoleManager<IdentityRole> _roleManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            context = _context;
            roleManager = _roleManager;
        }
       
        public IActionResult Index()
        {
            var admins = (from user in context.Users
                          join userRoles in context.UserRoles
                          on user.Id equals userRoles.UserId
                          join role in context.Roles
                          on userRoles.RoleId equals role.Id where role.Name == "Admin" select user).ToList();
            return View(admins);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminVM newAdmin)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser admin = new ApplicationUser();// create new application user to create user name, password
                admin.UserName = newAdmin.Email;
                admin.Email = newAdmin.Email;
                var result = await userManager.CreateAsync(admin,newAdmin.Password);
                if (result.Succeeded)
                {

                    var assignResult = await userManager.AddToRoleAsync(admin, "Admin");
                    return RedirectToAction("Index");
                  

                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(newAdmin);
        }

        
    }
}
