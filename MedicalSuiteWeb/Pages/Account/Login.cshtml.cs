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
                SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString());
                string cmdText = "SELECT PasswordHash FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);

                // Add the @email parameter
                cmd.Parameters.AddWithValue("@email", LoginUser.Email);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        string passwordHash = reader.GetString(0);
                        if(SecurityHelper.verifyPassword(LoginUser.Password, passwordHash))
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
                conn.Close();
                return RedirectToPage("Profile");

            } else
            {
                return Page();
            }

        }

        private bool ValidateCredentials()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT PasswordHash, PersonId FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);

                // Add the @email parameter
                cmd.Parameters.AddWithValue("@email", LoginUser.Email);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        return false;
                    }
                    else { 
                        string passwordHash = reader.GetString(0);
                        if (SecurityHelper.verifyPassword(LoginUser.Password, passwordHash))
                        {
                            //Get the PersonId, and use it to update the Person record
                            int personId = reader.GetInt32(1);
                            UpdatePersonLoginTime(personId);
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
    }
}
