using MedicalSuiteBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Prescriptions
{
    [BindProperties]
    [Authorize(Roles = "Doctor, Nurse")]
    public class EditPrescriptionModel : PageModel
    {
        public MedicalSuiteWeb.Model.Prescription EditedPrescription { get; set; } = new MedicalSuiteWeb.Model.Prescription();

        public List<SelectListItem> People { get; set; } = new List<SelectListItem>();

        public IActionResult OnGet(int id)
        {
            PopulatePrescription(id);
            PopulatePersonDDL();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                UpdatePrescription();
                return RedirectToPage("ViewPrescriptions");
            }
            else
            {
                PopulatePersonDDL();
                return Page();
            }
        }

        private void PopulatePrescription(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"SELECT PrescriptionName, PrescriptionStrength, 
                                           PrescriptionQuantity, PrescriptionDirections, 
                                           WrittenDate, ExpirationDate, Notes, CategoryId 
                                    FROM Prescription 
                                    WHERE PrescriptionId = @id";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    EditedPrescription.PrescriptionName = reader.GetString(0);
                    EditedPrescription.PrescriptionStrength = reader.GetString(1);
                    EditedPrescription.PrescriptionQuantity = reader.GetString(2);
                    EditedPrescription.PrescriptionDirections = reader.GetString(3);
                    EditedPrescription.WrittenDate = reader.GetDateTime(4);
                    EditedPrescription.ExpirationDate = reader.GetDateTime(5);
                    EditedPrescription.Notes = reader.GetString(6);
                    EditedPrescription.CategoryId = reader.GetInt32(7);
                }
            }
        }

        private void UpdatePrescription()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"UPDATE Prescription 
                                    SET PrescriptionName = @name, PrescriptionStrength = @strength, 
                                        PrescriptionQuantity = @quantity, PrescriptionDirections = @directions, 
                                        WrittenDate = @writtenDate, ExpirationDate = @expirationDate, 
                                        Notes = @notes, CategoryId = @categoryId 
                                    WHERE PrescriptionId = @id";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@name", EditedPrescription.PrescriptionName);
                cmd.Parameters.AddWithValue("@strength", EditedPrescription.PrescriptionStrength);
                cmd.Parameters.AddWithValue("@quantity", EditedPrescription.PrescriptionQuantity);
                cmd.Parameters.AddWithValue("@directions", EditedPrescription.PrescriptionDirections);
                cmd.Parameters.AddWithValue("@writtenDate", EditedPrescription.WrittenDate);
                cmd.Parameters.AddWithValue("@expirationDate", EditedPrescription.ExpirationDate);
                cmd.Parameters.AddWithValue("@notes", EditedPrescription.Notes);
                cmd.Parameters.AddWithValue("@categoryId", EditedPrescription.CategoryId);
                cmd.Parameters.AddWithValue("@id", EditedPrescription.PrescriptionId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
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
    }
}
