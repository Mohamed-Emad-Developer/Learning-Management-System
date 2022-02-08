using CollegeMS.Data;
using CollegeMS.viewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly CollegeDB context;

        public RoleController(RoleManager<IdentityRole> _roleManager, CollegeDB _context)
        {
            roleManager = _roleManager;
            context = _context;
        }
        public IActionResult Index()
        {
            var roles = context.Roles.ToList();

            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleVM newRole)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole();
                role.Name = newRole.Name;
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError("", "This Role Name Was Taken..");
            }
            return View(newRole);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var roleInDb = await roleManager.FindByIdAsync(id);
            if (roleInDb == null)
                return NotFound();
            var rolVM = new RoleVM { Id = roleInDb.Id, Name = roleInDb.Name };
            return View(rolVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] string id, RoleVM role)
        {
            var roleInDB = await roleManager.FindByIdAsync(id);
            if(roleInDB == null)
                return NotFound(role.Name); 
            roleInDB.Name = role.Name;
            var result = await roleManager.UpdateAsync(roleInDB);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
                foreach(var error in result.Errors) { ModelState.AddModelError("", error.Description); }

            return View(role);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var roleInDb = await roleManager.FindByIdAsync(id);
            if(roleInDb == null)
                return NotFound();

            var result = await roleManager.DeleteAsync(roleInDb);

            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }

            return NotFound();

        }
    }
}
