using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace MedicalSuiteWeb.Pages.Appointments
{
    public class ViewAllAppointmentsModel : PageModel
    {
        public List<Appointment> AppointmentList { get; set; } = new List<Appointment>();
        public void OnGet()
        {
            PopulateAppointmentList();
        }
        private List<Appointment> PopulateAppointmentList()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT AppointmentId, AppointmentDate, AppointmentTime FROM Appointments";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
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
                        AppointmentList.Add(appointment);
                    }
                }
            }
            return AppointmentList;
        }
    }
}
