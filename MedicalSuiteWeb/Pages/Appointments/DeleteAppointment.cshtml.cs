using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;

namespace MedicalSuiteWeb.Pages.Appointments
{
    [Authorize(Roles = "Doctor, Nurse, Patient")]
    public class DeleteAppointmentModel : PageModel
    {
       
        public IActionResult OnGet(int id)
        {
            // Delete appointment from the database
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Appointments WHERE AppointmentId = @AppointmentId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@AppointmentId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewAppointments");
            }
        }
    }
}
