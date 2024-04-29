using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace MedicalSuiteWeb.Pages.Appointments
{

    [BindProperties]
    public class ViewAppointmentsModel : PageModel
    {
        public List<Appointment> AppointmentList { get; set; } = new List<Appointment>();

        public void OnGet()
        {
            // Fetch Id of person currently logged in
            int personId = GetCurrentlyLoggedInPersonId();

            // Fetch appointments only for the current user
            AppointmentList = PopulateAppointmentList(personId);
        }

        public void OnPostDelete(int id)
        {
            // Delete logic is the same as the DeleteAppointments.cshtml.cs logic
        }

        private int GetCurrentlyLoggedInPersonId()
        {
            return int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.Actor));
        }

        private List<Appointment> PopulateAppointmentList(int personId)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {

                string cmdText = "SELECT AppointmentId, AppointmentDate, AppointmentTime, AppointmentNotes, DoctorsName FROM Appointments WHERE PersonId = @PersonId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@PersonId", personId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var appointment = new Appointment();
                        appointment.AppointmentId = reader.GetInt32(0);
                        appointment.AppointmentDate = reader.GetDateTime(1);
                        appointment.AppointmentTime = reader.GetTimeSpan(2);
                        appointment.AppointmentNotes = reader.GetString(3);
                        appointment.DoctorsName = reader.GetString(4);
                        AppointmentList.Add(appointment);
                    }
                }
            }
            return AppointmentList;
        }

    }
}
