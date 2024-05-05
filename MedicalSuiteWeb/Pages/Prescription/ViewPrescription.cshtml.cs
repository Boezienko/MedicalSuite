using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Prescriptions
{
    [Authorize(Roles = "Doctor, Nurse")]
    [BindProperties]
    public class ViewPrescriptionsModel : PageModel
    {
        public List<SelectListItem> People { get; set; } = new List<SelectListItem>();

        public List<MedicalSuiteWeb.Model.Prescription> Prescriptions { get; set; } = new List<MedicalSuiteWeb.Model.Prescription>();

        public int SelectedPersonId { get; set; }

        public void OnGet()
        {
            PopulatePrescriptions(SelectedPersonId);
            PopulatePersonDDL();
        }

        public void OnPost()
        {
            PopulatePrescriptions(SelectedPersonId);
            PopulatePersonDDL();
        }

        private void PopulatePrescriptions(int personId)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"SELECT PrescriptionName, PrescriptionStrength, 
                                           PrescriptionQuantity, PrescriptionDirections, 
                                           WrittenDate, ExpirationDate, Notes, CategoryId 
                                    FROM Prescription 
                                    JOIN Person ON PersonId = PersonId
                                    WHERE PersonId = @personId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@personId", personId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var prescription = new MedicalSuiteWeb.Model.Prescription();
                        prescription.PrescriptionName = reader.GetString(0);
                        prescription.PrescriptionStrength = reader.GetString(1);
                        prescription.PrescriptionQuantity = reader.GetString(2);
                        prescription.PrescriptionDirections = reader.GetString(3);
                        prescription.WrittenDate = reader.GetDateTime(4);
                        prescription.ExpirationDate = reader.GetDateTime(5);
                        prescription.Notes = reader.GetString(6);
                        prescription.CategoryId = reader.GetInt32(7);
                        Prescriptions.Add(prescription);
                    }
                }
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
                        if (person.Value == SelectedPersonId.ToString())
                        {
                            person.Selected = true;
                        }
                        People.Add(person);
                    }
                }
            }
        }
    }
}
