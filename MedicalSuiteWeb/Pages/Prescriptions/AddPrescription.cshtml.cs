using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;

namespace MedicalSuiteWeb.Pages.Prescriptions
{
    [BindProperties]
    [Authorize(Roles = "Doctor")]
    public class AddPrescriptionModel : PageModel
    {
        public MedicalSuiteWeb.Model.Prescription newPrescription { get; set; } = new MedicalSuiteWeb.Model.Prescription();

        public List<SelectListItem> listOfPatients { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> listOfSchedules { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> listOfDoctors { get; set; } = new List<SelectListItem>();

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Prescription(PrescriptionName, PrescriptionStrength, PrescriptionQuantity, PrescriptionDirections, WrittenDate, ExpirationDate, PrescriptionScheduleId, PersonId, DoctorsName) " +
                        "VALUES (@name, @strength, @quantity, @directions, @writtenDate, @expirationDate, @scheduleId, @personId, @doctorsName)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@name", newPrescription.PrescriptionName);
                    cmd.Parameters.AddWithValue("@strength", newPrescription.PrescriptionStrength);
                    cmd.Parameters.AddWithValue("@quantity", newPrescription.PrescriptionQuantity);
                    cmd.Parameters.AddWithValue("@directions", newPrescription.PrescriptionDirections);
                    cmd.Parameters.AddWithValue("@writtenDate", newPrescription.WrittenDate);
                    cmd.Parameters.AddWithValue("@expirationDate", newPrescription.ExpirationDate);
                    cmd.Parameters.AddWithValue("@scheduleId", newPrescription.PrescriptionScheduleId);
                    cmd.Parameters.AddWithValue("@personId", newPrescription.PersonId);
                    cmd.Parameters.AddWithValue("@doctorsName", newPrescription.DoctorsName);
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

        public void OnGet()
        {
            PopulatePersonDDL();
            PopulateSchedulesDDL();
            PopulateDoctorsDDL();
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
                        schedule.Text= reader.GetString(1).ToString();
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