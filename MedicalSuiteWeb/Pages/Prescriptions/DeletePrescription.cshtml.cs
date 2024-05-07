using MedicalSuiteBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Prescriptions
{
    [Authorize(Roles = "Doctor")]
    public class DeletePrescriptionModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Prescription WHERE PrescriptionId = @scriptId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@scriptId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewPrescriptions");
            }
        }
    }
}
