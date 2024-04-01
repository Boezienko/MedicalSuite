using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedicalSuiteWeb.Model;

namespace MedicalSuiteWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        public Login LoginUser { get; set; }
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("Profile");
            } else
            {
                return Page();
            }

        }
    }
}
