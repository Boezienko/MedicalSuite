using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Prescriptions
{
    [BindProperties]
    [Authorize(Roles = "Doctor")]
    public class AddPrescriptionModel : PageModel
    {
        public MedicalSuiteWeb.Model.Prescription NewPrescription { get; set; } = new MedicalSuiteWeb.Model.Prescription();

        public List<SelectListItem> People { get; set; } = new List<SelectListItem>();

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Prescription(PrescriptionName, PrescriptionStrength, PrescriptionQuantity, PrescriptionDirections, WrittenDate, ExpirationDate, Notes, PrescriptionScheduleId, PersonId) " +
                        "VALUES (@name, @strength, @quantity, @directions, @writtenDate, @expirationDate, @notes, @categoryId)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@name", NewPrescription.PrescriptionName);
                    cmd.Parameters.AddWithValue("@strength", NewPrescription.PrescriptionStrength);
                    cmd.Parameters.AddWithValue("@quantity", NewPrescription.PrescriptionQuantity);
                    cmd.Parameters.AddWithValue("@directions", NewPrescription.PrescriptionDirections);
                    cmd.Parameters.AddWithValue("@writtenDate", NewPrescription.WrittenDate);
                    cmd.Parameters.AddWithValue("@expirationDate", NewPrescription.ExpirationDate);
                    cmd.Parameters.AddWithValue("@notes", NewPrescription.Notes);
                    cmd.Parameters.AddWithValue("@categoryId", NewPrescription.CategoryId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewPrescription");

                }
            }
            else
            {
                return Page();
            }
        }

        public List<SelectListItem> patients { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            //PopulatePersonDDL();
        }

        private void PopulatePersonDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT PersonId, FirstName, LastName FROM Person ORDER BY LastName";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var person = new SelectListItem();
                        person.Value = reader.GetInt32(0).ToString();
                        person.Text = $"{reader.GetString(1)} {reader.GetString(2)}";
                        People.Add(person);
                    }
                }
            }
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