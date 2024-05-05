using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalSuiteWeb.Pages.Prescription
{
    [Authorize(Roles = "Doctor, Nurse")]
    [BindProperties]
    public class AddPrescriptionModel : PageModel
    {
        public Prescription2 newPrescription { get; set; } = new Prescription2();

        public List<SelectListItem> patients { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            //PopulateCategoryDDL();
        }

        /*public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Prescription(PrescriptionId, PrescriptionName, PrescriptionStrength, PrescriptionQuantity, PrescriptionDirections, WrittenDate, ExpirationDate, Notes, CategoryId) " + 
                        "VALUES (@prescriptionId, @prescriptionName, @prescriptionStrength, @prescriptionQuantity, @prescriptionDirections, @writtenDate, @expirationDate, @notes, @categoryId)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@prescriptionId", newInventoryItem.InventoryItemCode);
                    cmd.Parameters.AddWithValue("@prescriptionName", newInventoryItem.InventoryItemName);
                    cmd.Parameters.AddWithValue("@prescriptionStrength", newInventoryItem.InventoryItemDescription);
                    cmd.Parameters.AddWithValue("@prescriptionQuantity", newInventoryItem.InventoryItemPrice);
                    cmd.Parameters.AddWithValue("@prescriptionDirections", newInventoryItem.CategoryId);
                    cmd.Parameters.AddWithValue("@writtenDate", newInventoryItem.CategoryId);
                    cmd.Parameters.AddWithValue("@expirationDate", newInventoryItem.CategoryId);
                    cmd.Parameters.AddWithValue("@notes", newInventoryItem.CategoryId);
                    cmd.Parameters.AddWithValue("@categoryId", newInventoryItem.CategoryId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewPrescriptions");

                }
            }
            else
            {
                return Page();
            }
        }
         private void PopulateCategoryDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName FROM Person ORDER BY LastName";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var category = new SelectListItem();
                        category.Value = reader.GetString(0).ToString();
                        category.Text = reader.GetString(1).ToString();
                        Categories.Add(category);
                    }

                }
            }
        }
         */
    }
}
