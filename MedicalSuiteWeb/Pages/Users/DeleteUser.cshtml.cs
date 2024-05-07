using MedicalSuiteBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Users
{
    [Authorize(Roles = "Doctor, Nurse")]
    public class DeleteUserModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            // Delete person from the database
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Person WHERE PersonId = @personId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@personId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewUsers");
            }
        }
    }
}
