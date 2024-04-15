using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedicalSuiteWeb.Model;
using Microsoft.Data.SqlClient;
using MedicalSuiteBusiness;

namespace MedicalSuiteWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LoginUser { get; set; }
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                SqlDataReader reader = ValidateCredentials();
                if (reader != null && reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        string passwordHash = reader.GetString(0);
                        if (SecurityHelper.verifyPassword(LoginUser.Password, passwordHash))
                        {
                            return RedirectToPage("Profile");
                        }
                        else
                        {
                            ModelState.AddModelError("LoginError", "Invalid credentials. Try again.");
                            return Page();
                        }
                    }
                    else
                    {
                        return Page();
                    }
                }
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
        }

        private SqlDataReader ValidateCredentials()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT PasswordHash, PersonId, FirstName, Email FROM Person " +
                    " INNER JOIN [Role] ON Person.RoleId = [Role].RoleId WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);

                // Add the @email parameter
                cmd.Parameters.AddWithValue("@email", LoginUser.Email);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return reader;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
