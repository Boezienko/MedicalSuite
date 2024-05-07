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
    public class EditPrescriptionModel : PageModel
    {
        public Model.Prescription specifiedPrescription { get; set; } = new Model.Prescription();

        public List<SelectListItem> listOfPatients { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> listOfSchedules { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> listOfDoctors { get; set; } = new List<SelectListItem>();
        public void OnGet(int id)
        {
            PopulatePrescription(id);
            PopulatePersonDDL();
            PopulateSchedulesDDL();
            PopulateDoctorsDDL();
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE Prescription SET PrescriptionName = @name, PrescriptionStrength = @strength, PrescriptionQuantity = @quantity, PrescriptionDirections = @directions, WrittenDate = @writtenDate, ExpirationDate = @expirationDate, PrescriptionScheduleId = @scheduleId, PersonId = @personId, DoctorsName = @doctorsName FROM Prescription WHERE PrescriptionId = @prescriptionId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@name", specifiedPrescription.PrescriptionName);
                    cmd.Parameters.AddWithValue("@strength", specifiedPrescription.PrescriptionStrength);
                    cmd.Parameters.AddWithValue("@quantity", specifiedPrescription.PrescriptionQuantity);
                    cmd.Parameters.AddWithValue("@directions", specifiedPrescription.PrescriptionDirections);
                    cmd.Parameters.AddWithValue("@writtenDate", specifiedPrescription.WrittenDate);
                    cmd.Parameters.AddWithValue("@expirationDate", specifiedPrescription.ExpirationDate);
                    cmd.Parameters.AddWithValue("@scheduleId", specifiedPrescription.PrescriptionScheduleId);
                    cmd.Parameters.AddWithValue("@personId", specifiedPrescription.PersonId);
                    cmd.Parameters.AddWithValue("@doctorsName", specifiedPrescription.DoctorsName);
                    cmd.Parameters.AddWithValue("@prescriptionId", id);
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
        private void PopulatePrescription(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT PrescriptionId, PrescriptionName, PrescriptionStrength, PrescriptionQuantity, PrescriptionDirections, WrittenDate, ExpirationDate, PrescriptionScheduleId, PersonId, DoctorsName FROM  Prescription WHERE PrescriptionId = @prescriptionId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@prescriptionId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    specifiedPrescription.PrescriptionId = reader.GetInt32(0);
                    specifiedPrescription.PrescriptionName = reader.GetString(1);
                    specifiedPrescription.PrescriptionStrength = reader.GetString(2);
                    specifiedPrescription.PrescriptionQuantity = reader.GetString(3);
                    specifiedPrescription.PrescriptionDirections = reader.GetString(4);
                    specifiedPrescription.WrittenDate = reader.GetDateTime(5);
                    specifiedPrescription.ExpirationDate = reader.GetDateTime(6);
                    specifiedPrescription.PrescriptionScheduleId = reader.GetInt32(7);
                    specifiedPrescription.PersonId = reader.GetInt32(8);
                    specifiedPrescription.DoctorsName = reader.GetString(9);
                }
            }
        }

        private void PopulatePersonDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT PersonId, FirstName, LastName FROM Person WHERE RoleId = 3 ORDER BY LastName";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var person = new SelectListItem();
                        person.Value = reader.GetInt32(0).ToString();
                        person.Text = $"{reader.GetString(2)}, {reader.GetString(1)}";
                        listOfPatients.Add(person);
                    }
                }
            }
        }

        private void PopulateSchedulesDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT PrescriptionScheduleId, PrescriptionSchedules FROM PrescriptionSchedule ORDER BY PrescriptionSchedules";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var schedule = new SelectListItem();
                        schedule.Value = reader.GetInt32(0).ToString();
                        schedule.Text = reader.GetString(1).ToString();
                        listOfSchedules.Add(schedule);
                    }
                }
            }
        }

        private void PopulateDoctorsDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName FROM Person WHERE RoleId = 1";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var doctor = new SelectListItem();
                        doctor.Value = $"Dr. {reader.GetString(0)} {reader.GetString(1)}";
                        doctor.Text = $"Dr. {reader.GetString(0)} {reader.GetString(1)}";
                        listOfDoctors.Add(doctor);
                    }
                }
            }
        }
    }
}
