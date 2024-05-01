using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace MedicalSuiteWeb.Pages.Appointments
{
    [BindProperties]

    [Authorize(Roles = "Doctor, Nurse, Patient")]
    public class AddAppointmentModel : PageModel
    {
        public Appointment newAppointment { get; set; } = new Appointment();

        // public List<SelectListItem> ListOfAppointments { get; set; } = new List<SelectListItem>(); //I don't think this is necessary, just put it here for safekeeping

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            int personId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.Actor));
            
            if (ModelState.IsValid)
            {

                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Appointments(AppointmentDate, AppointmentTime, AppointmentNotes, DoctorsName, PersonId) " +
                                     "VALUES (@appointmentDate, @appointmentTime, @appointmentNotes, @doctorsName, @PersonId)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@appointmentDate", newAppointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@appointmentTime", newAppointment.AppointmentTime);
                    cmd.Parameters.AddWithValue("@appointmentNotes", newAppointment.AppointmentNotes);
                    cmd.Parameters.AddWithValue("@doctorsName", newAppointment.DoctorsName);
                    cmd.Parameters.AddWithValue("@PersonId", personId);
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
    }
}
