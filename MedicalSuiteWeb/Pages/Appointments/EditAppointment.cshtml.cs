using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Appointments
{
    [BindProperties]

    [Authorize(Roles = "Doctor, Nurse, Patient")]
    public class EditAppointmentModel : PageModel
    {
        public Appointment specifiedAppointment { get; set; } = new Appointment();

        public IActionResult OnPost(int id)
        {

            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE Appointments SET AppointmentDate = @appointmentDate, AppointmentTime = @appointmentTime, AppointmentNotes = @appointmentNotes, DoctorsName = @doctorsName WHERE AppointmentId = @appointmentId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);                   
                    cmd.Parameters.AddWithValue("@appointmentDate", specifiedAppointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@appointmentTime", specifiedAppointment.AppointmentTime);
                    cmd.Parameters.AddWithValue("@appointmentNotes", specifiedAppointment.AppointmentNotes);
                    cmd.Parameters.AddWithValue("@doctorsName", specifiedAppointment.DoctorsName);
                    cmd.Parameters.AddWithValue("@appointmentId", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewAppointments");

                }
            }
            else
            {
                return Page();
            }
        }

        public void OnGet(int id)
        {
            PopulateAppointment(id);
        }

        private void PopulateAppointment(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT AppointmentId, AppointmentDate, AppointmentTime, AppointmentNotes, DoctorsName FROM Appointments WHERE AppointmentId=@appointmentId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@appointmentId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var AppointmentId = id;
                        specifiedAppointment.AppointmentId = id;
                        specifiedAppointment.AppointmentDate = reader.GetDateTime(1);
                        specifiedAppointment.AppointmentTime = reader.GetTimeSpan(2);
                        specifiedAppointment.AppointmentNotes = reader.GetString(3);
                        specifiedAppointment.DoctorsName = reader.GetString(4);
                    }
                }
            }
        }
    }
}
