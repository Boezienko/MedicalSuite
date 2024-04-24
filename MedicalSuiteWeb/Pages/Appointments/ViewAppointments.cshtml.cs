using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Appointments
{
    [BindProperties]
    public class ViewAppointmentsModel : PageModel
    {
        public List<Appointment> AppointmentList { get; set; } = new List<Appointment>();

        public void OnGet()
        {
            // Fetch Id of person currently logged in
            int personId = GetCurrentlyLoggedInPersonId(); // Implement this method

            // Fetch appointments only for the current user
            AppointmentList = PopulateAppointmentList(personId);
        }

        private int GetCurrentlyLoggedInPersonId()
        {
            return 1;
        }

        private List<Appointment> PopulateAppointmentList(int personId)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM Appointments WHERE PersonId = @PersonId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@PersonId", personId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment();
                        appointment.AppointmentId = reader.GetInt32(0);
                        appointment.AppointmentDate = reader.GetDateTime(1);
                        appointment.AppointmentTime = reader.GetTimeSpan(2);
                        AppointmentList.Add(appointment);
                    }
                }
            }
            return AppointmentList;
        }
    }
}
