using MedicalSuiteBusiness;
using MedicalSuiteWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
namespace MedicalSuiteWeb.Pages.Users
{
    [BindProperties]

    [Authorize(Roles = "Doctor, Nurse")]

    public class AddUserModel : PageModel
    {
        public Person newUser { get; set; } = new Person();
        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            PopulateRoleDDL();

        }

        private void PopulateRoleDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT RoleId, RoleName FROM Role ORDER BY RoleName DESC";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var role = new SelectListItem();
                        role.Value = reader.GetInt32(0).ToString();
                        role.Text = reader.GetString(1).ToString();
                        Roles.Add(role);
                    }

                }
            }
        }

        public IActionResult OnPost()

        {
            if (ModelState.IsValid)
            {
                // Check if email already exists in DB

                if (EmailDNE(newUser.Email)) //DNE - Does Not Exist
                {
                    RegisterUser();
                    return RedirectToPage("ViewUsers");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "The email address already exists, please try another.");
                    return Page();
                }

            }
            else
            {
                return Page();
            }
        }
        private void RegisterUser()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                //2. Create a insert command
                string cmdText = "INSERT INTO Person(FirstName, LastName, Email, PasswordHash, Telephone, LastLoginTime, RoleId)" +
                    "VALUES(@firstName, @lastName, @email, @password, @telephone, @lastLoginTime, @roleId)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@firstName", newUser.FirstName);
                cmd.Parameters.AddWithValue("@lastName", newUser.LastName);
                cmd.Parameters.AddWithValue("@email", newUser.Email);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.generatePasswordHash(newUser.Password));               
                cmd.Parameters.AddWithValue("@telephone", newUser.Telephone);
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@roleId", newUser.RoleId);
               
                //3. Open the database 
                conn.Open();
                //4.Execute the command 
                cmd.ExecuteNonQuery();
                //5. Close the database
                conn.Close();
            }
        }

        private bool EmailDNE(string email) // Check given email. If it already exists ret false. Otherwise ret true.
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}

