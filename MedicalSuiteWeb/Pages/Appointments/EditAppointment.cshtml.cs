using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Appointments
{
    [BindProperties]
    public class EditAppointmentModel : PageModel
    {
        public Appointment specifiedAppointment { get; set; } = new Appointment();
        public void OnGet(int id)
        {
            PopulateAppointment(id);
        }

        private void PopulateAppointment(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT AppointmentId, AppointmentDate, AppointmentTime FROM Appointments WHERE AppointmentId=@appointmentId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@appointmentId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    specifiedAppointment.AppointmentId = id;
                    specifiedAppointment.AppointmentDate = reader.GetDateTime(1);
                    specifiedAppointment.AppointmentTime = reader.GetTimeSpan(2);
                }
            }
        }
    }
}
