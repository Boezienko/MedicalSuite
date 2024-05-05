using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedicalSuiteWeb.Model;

namespace MedicalSuiteWeb.Pages.Prescription
{
    [Authorize(Roles = "Doctor, Nurse")]
    [BindProperties]
    public class AddPrescriptionModel : PageModel
    {
        public Prescription2 newPrescription { get; set; } = new Prescription2();

        public void OnGet()
        {
        }
    }
}
