using MedicalSuiteBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Inventories
{
    [Authorize(Roles = "Doctor, Nurse")]
    public class DeleteInventoryItemModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            // Delete appointment from the database
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM InverntoryItem WHERE InventoryItemId = @InventoryItemId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@InventoryItemId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewInventoryItems");
            }
            
        }
    }
}
