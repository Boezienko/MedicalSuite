using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Security.Claims;

namespace MedicalSuiteWeb.Pages.Account
{
    [BindProperties]

    public class ForgotPasswordModel : PageModel
    {
        public PasswordChangePerson user { get; set; } = new PasswordChangePerson();
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Password entered: " + user.Password);
                //string email = HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE PERSON SET PasswordHash = @passwordHash WHERE Email = @email ";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@passwordHash", SecurityHelper.generatePasswordHash(user.Password));
                    cmd.Parameters.AddWithValue("@email", user.Email);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("Login");
                }
            }
            else
            {
                return (Page());
            }           
        }
    }
}
