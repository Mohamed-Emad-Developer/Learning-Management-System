using CollegeMS.Data;
using CollegeMS.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace CollegeMS.Services.Repository
{
    public class ApplicationUserRepository:IApplicationUserRepository
    {
        CollegeDB DB;
        public ApplicationUserRepository(CollegeDB _DB)
        {
            DB = _DB;
        }
        public string getNamebyid(string id)
        {
            ApplicationUser user= DB.Users.FirstOrDefault(ww => ww.Id == id);
            
            return user.Name;
        }
    }
}
