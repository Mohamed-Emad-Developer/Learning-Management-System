using System.ComponentModel.DataAnnotations;

namespace CollegeMS.viewModel
{
    public class RoleVM
    {
        public string Id { get; set; }

        [Display(Name ="Role Name")]
        public string Name { get; set; }
    }
}
