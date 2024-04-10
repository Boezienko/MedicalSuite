using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalSuiteWeb.Pages.Account
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public UserProfile profile {  get; set; }

        public void OnGet()
        {
        }
    }
}
