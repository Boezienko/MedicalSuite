using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedicalSuiteWeb.Model;
using Microsoft.Data.SqlClient;
using MedicalSuiteBusiness;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MedicalSuiteWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LoginUser { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (ValidateCredentials())
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
                ModelState.AddModelError("loginError", "MODEL STATE INVALID");
                return Page();
            }

        }

        private void UpdatePersonLoginTime(int personId)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "UPDATE Person SET LastLoginTime=@lastLoginTime WHERE PersonId=@personId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@personId", personId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidateCredentials()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT PasswordHash, PersonId, FirstName, RoleName FROM Person " +
                    " INNER JOIN [Role] ON Person.RoleId = [Role].RoleId WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);

                // Add the @email parameter
                cmd.Parameters.AddWithValue("@email", LoginUser.Email);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (reader.IsDBNull(0))
                    {
                        return false;
                    }
                    else
                    {
                        string passwordHash = reader.GetString(0);
                        if (SecurityHelper.verifyPassword(LoginUser.Password, passwordHash))
                        {

                            int personId = reader.GetInt32(1);
                            UpdatePersonLoginTime(personId);

                            // Create principle
                            string name = reader.GetString(2);
                            string roleName = reader.GetString(3);

                            //create a list of claims
                            Claim emailClaim = new Claim(ClaimTypes.Email, LoginUser.Email);
                            Claim nameClaim = new Claim(ClaimTypes.Name, name);
                            Claim roleClaim = new Claim(ClaimTypes.Role, roleName);

                            List<Claim> claims = new List<Claim> { emailClaim, nameClaim, roleClaim };

                            // add list of claims to claimsIdentity
                            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            //add the identity to a ClaimsPrincipal
                            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                            // call httpContext.signInAsync() method to encrypt the principal
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
