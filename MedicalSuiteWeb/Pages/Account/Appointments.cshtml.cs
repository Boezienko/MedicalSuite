using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Numerics;

namespace MedicalSuiteWeb.Pages.Account
{

    public class AppointmentsModel : PageModel
    {
        [BindProperty]
        public Appointments NewAppointment { get; set; }

        // List to store upcoming appointments
        public List<Appointments> UpcomingAppointments { get; set; } = new List<Appointments>();

        public IActionResult OnPost() 
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Appointments(AppointmentDate, AppointmentTime, AppointmentNotes, DoctorsName, PersonId) " +
                        "VALUES (@date, @time, @notes, @doctor, @personId)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@date", NewAppointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@time", NewAppointment.AppointmentTime);
                    cmd.Parameters.AddWithValue("@notes", NewAppointment.AppointmentNotes);
                    cmd.Parameters.AddWithValue("@doctor", NewAppointment.DoctorsName);
                    cmd.Parameters.AddWithValue("@personId", NewAppointment.PersonId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Clear the form fields
                NewAppointment = new Appointments();

                return RedirectToPage();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
