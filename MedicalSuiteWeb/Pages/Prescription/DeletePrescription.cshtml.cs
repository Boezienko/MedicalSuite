using MedicalSuiteBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Prescription
{
    [Authorize(Roles = "Doctor, Nurse")]
    public class DeletePrescriptionModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            // Delete appointment from the database
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Prescription WHERE PrescriptionId = @PrescriptionId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@PrescriptionId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewPrescription");
            }
        }
    }
}
