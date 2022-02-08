using CollegeMS.Models;
using CollegeMS.viewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CollegeMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManger;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController
            (UserManager<ApplicationUser> _userManger, SignInManager<ApplicationUser> _signInManager,RoleManager<IdentityRole> _roleManager)
        {

            userManger = _userManger;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }
        public IActionResult Login( string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser, string ReturnUrl )
        {
            if (ModelState.IsValid == true)
            {
                var user = await userManger.FindByNameAsync(loginUser.UserName);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync
                        (user, loginUser.Password, loginUser.IsPersiste, false);
                    if (result.Succeeded)
                    {
                        #region check user role

                        if (await userManger.IsInRoleAsync(user,"Instructor"))
                        {
                            ReturnUrl = ReturnUrl== null ? $"/Instructor/Details/{user.Id}" : ReturnUrl;
                            return LocalRedirect(ReturnUrl);

                        }
                        else if (await userManger.IsInRoleAsync(user, "Admin"))
                        {
                            ReturnUrl = ReturnUrl == null ? "/Admin/Index" : ReturnUrl;
                            return LocalRedirect(ReturnUrl);
                        }
                        else if (await userManger.IsInRoleAsync(user, "Student"))
                        {
                            ReturnUrl = ReturnUrl == null? $"/Student/Details/{user.Id}":ReturnUrl;
                            return LocalRedirect(ReturnUrl);
                        }
                        #endregion
                    }
                    else
                    {
                        
                        ModelState.AddModelError("", "Incorrect UserName or Password");
                    }

                }
                else
                {

                    ModelState.AddModelError("", "Invalid UserName or Password");
                    return View(loginUser);
                }
            }
            ViewData["ReturnUrl"] = ReturnUrl;
            return View(loginUser);
            //return LocalRedirect(ReturnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


    }
}
