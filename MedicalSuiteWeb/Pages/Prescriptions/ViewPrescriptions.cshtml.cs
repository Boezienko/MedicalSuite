using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace MedicalSuiteWeb.Pages.Prescriptions
{
    [Authorize(Roles = "Doctor, Nurse, Patient")]
    [BindProperties]
    public class ViewPrescriptionsModel : PageModel
    {
        public List<SelectListItem> listOfPeople { get; set; } = new List<SelectListItem>();

        public List<MedicalSuiteWeb.Model.Prescription> listOfPrescriptions { get; set; } = new List<MedicalSuiteWeb.Model.Prescription>();

        public int SelectedPersonId { get; set; }
        public void OnGet()
        {
            // Fetch Id of person currently logged in
            int personId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.Actor));
            string userRole = HttpContext.User.FindFirstValue(ClaimTypes.Role).ToString();
            PopulatePrescriptions(personId, userRole);
            //PopulatePersonDDL();
        }

        public void OnPost()
        {
        }
        private void PopulatePrescriptions(int userId, string role)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = string.Empty;
                if (role.Equals("Doctor") || role.Equals("Nurse"))
                {
                    cmdText = "SELECT PrescriptionId, PrescriptionName, PrescriptionStrength, PrescriptionQuantity, PrescriptionDirections, WrittenDate, ExpirationDate, PrescriptionScheduleId, PersonId, DoctorsName FROM Prescription";
                }
                else
                {
                    cmdText = "SELECT PrescriptionId, PrescriptionName, PrescriptionStrength, PrescriptionQuantity, PrescriptionDirections, WrittenDate, ExpirationDate, PrescriptionScheduleId, PersonId, DoctorsName FROM Prescription WHERE PersonId = @userId";
                }
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var prescription = new MedicalSuiteWeb.Model.Prescription();
                        prescription.PrescriptionId = reader.GetInt32(0);
                        prescription.PrescriptionName = reader.GetString(1);
                        prescription.PrescriptionStrength = reader.GetString(2);
                        prescription.PrescriptionQuantity = reader.GetString(3);
                        prescription.PrescriptionDirections = reader.GetString(4);
                        prescription.WrittenDate = reader.GetDateTime(5);
                        prescription.ExpirationDate = reader.GetDateTime(6);
                        prescription.PrescriptionScheduleId = reader.GetInt32(7);
                        prescription.PersonId = reader.GetInt32(8);
                        prescription.DoctorsName = reader.GetString(9);
                        listOfPrescriptions.Add(prescription);
                    }
                }
            }
        }

        /*private void PopulatePersonDDL()
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
        }*/
    }
}