using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;

namespace MedicalSuiteWeb.Pages.Account
{
    [BindProperties]

    [Authorize(Roles = "Doctor, Nurse, Patient")]
    public class EditProfileModel : PageModel
    {
        public EditPerson user { get; set; } = new EditPerson();
        public void OnGet()
        {
            PopulateUser();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string email = HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE PERSON SET FirstName = @firstName, LastName = @lastName, Email = @email, Telephone = @telephone WHERE Email = @email ";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@telephone", user.Telephone);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("Profile");
                }
            }
            else
            {
                return Page();
            }
        }

        private void PopulateUser()
        {
            // query the person table to populate "profile" object

            string email = HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, Telephone FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user.FirstName = reader.GetString(0);
                    user.LastName = reader.GetString(1);
                    user.Email = reader.GetString(2);
                    user.Telephone = reader.GetString(3);                }
            }
        }
    }
}
