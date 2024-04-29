using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalSuiteWeb.Pages.Prescription
{
    [Authorize(Roles = "Doctor, Nurse")]
    public class AddPrescriptionModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
